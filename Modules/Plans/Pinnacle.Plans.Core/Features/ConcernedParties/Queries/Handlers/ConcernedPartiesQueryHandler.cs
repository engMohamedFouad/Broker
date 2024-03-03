using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Models;
using Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Handlers
{
    public class ConcernedPartiesQueryHandler : ResponseHandler,
        IRequestHandler<GetConcernedPartiesPaginationQuery, PaginatedResult<GetConcernedPartiesPaginationResult>>,
        IRequestHandler<GetConcernedPartiesByIdQuery, Response<GetConcernedPartiesByIdResult>>,
        IRequestHandler<GetMaxIdQuery, Response<int>>
    {
        #region Fields
        private readonly IConcernedPartyService _concernedPartyService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ConcernedPartiesQueryHandler(IConcernedPartyService concernedPartyService,
                                            IMapper mapper,
                                            IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _concernedPartyService = concernedPartyService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetConcernedPartiesPaginationResult>> Handle(GetConcernedPartiesPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _concernedPartyService.GetConcernedPartiesQuery(request.Search);
            var result = await _mapper.ProjectTo<GetConcernedPartiesPaginationResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetConcernedPartiesByIdResult>> Handle(GetConcernedPartiesByIdQuery request, CancellationToken cancellationToken)
        {
            var concernedParty = await _concernedPartyService.GetById(request.Id);
            if (concernedParty == null) return NotFound<GetConcernedPartiesByIdResult>();
            var result = _mapper.Map<GetConcernedPartiesByIdResult>(concernedParty);
            var numbers = await _concernedPartyService.GetPhoneNumbers(request.Id);
            result.PhoneNumbers = numbers;
            return Success(result);
        }

        public async Task<Response<int>> Handle(GetMaxIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _concernedPartyService.GetMaxIdAsync();
            return Success(result);
        }
        #endregion
    }
}
