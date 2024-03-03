using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Models;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Handlers
{
    public class FirstlyDataQueryHandler : ResponseHandler,
        IRequestHandler<GetFirstlyDataQuery, PaginatedResult<GetFirstlyDataResult>>,
        IRequestHandler<GetFirstlyDataByIdQuery, Response<GetFirstlyDataByIdResult>>
    {
        #region Fields
        private readonly IFirstlyInformationService _firstlyInformationService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public FirstlyDataQueryHandler(IFirstlyInformationService firstlyInformationService,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _firstlyInformationService=firstlyInformationService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetFirstlyDataResult>> Handle(GetFirstlyDataQuery request, CancellationToken cancellationToken)
        {
            var query = _firstlyInformationService.GetFirstlyDatasQuery(request.Search);
            var result = await _mapper.ProjectTo<GetFirstlyDataResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetFirstlyDataByIdResult>> Handle(GetFirstlyDataByIdQuery request, CancellationToken cancellationToken)
        {
            var firstlyData = await _firstlyInformationService.GetById(request.Id);
            if (firstlyData == null) return NotFound<GetFirstlyDataByIdResult>();
            var result = _mapper.Map<GetFirstlyDataByIdResult>(firstlyData);
            return Success(result);
        }
        #endregion
    }
}