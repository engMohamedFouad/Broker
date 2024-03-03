using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Managements.Queries.Models;
using Pinnacle.Plans.Core.Features.Managements.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Managements.Queries.Handlers
{
    public class ManagementsQueryHandler : ResponseHandler,
        IRequestHandler<GetManagementsQuery, PaginatedResult<GetManagementsResult>>,
        IRequestHandler<GetManagementByIdQuery, Response<GetManagementByIdResult>>
    {
        #region Fields
        private readonly IManagementService _managementService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ManagementsQueryHandler(IManagementService managementService,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _managementService=managementService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetManagementsResult>> Handle(GetManagementsQuery request, CancellationToken cancellationToken)
        {
            var query = _managementService.GetManagementsQuery(request.Search);
            var result = await _mapper.ProjectTo<GetManagementsResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetManagementByIdResult>> Handle(GetManagementByIdQuery request, CancellationToken cancellationToken)
        {
            var management = await _managementService.GetById(request.Id);
            if (management == null) return NotFound<GetManagementByIdResult>();
            var result = _mapper.Map<GetManagementByIdResult>(management);
            return Success(result);
        }

        #endregion
    }
}
