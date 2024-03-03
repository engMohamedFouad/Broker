using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Plans.Queries.Models;
using Pinnacle.Plans.Core.Features.Plans.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Plans.Queries.Handlers
{
    public class PlansQueryHandler : ResponseHandler,
        IRequestHandler<GetPlansPaginationQuery, PaginatedResult<GetPlansPaginationResult>>,
        IRequestHandler<GetPlanByIdQuery, Response<GetPlanByIdResult>>,
        IRequestHandler<GetMaxIdQuery, Response<int>>
    {
        #region Fields
        private readonly IPlanService _planService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion

        #region Constructors
        public PlansQueryHandler(IPlanService planService,
                                 IMapper mapper,
                                 IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _planService = planService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetPlansPaginationResult>> Handle(GetPlansPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _planService.GetyearlyPlansQuery(request.Year, request.ConcernedParty, request.EmployeeName, request.Status);
            var result = await _mapper.ProjectTo<GetPlansPaginationResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetPlanByIdResult>> Handle(GetPlanByIdQuery request, CancellationToken cancellationToken)
        {
            var yearlyPlan = await _planService.GetById(request.Id);
            if (yearlyPlan == null) return NotFound<GetPlanByIdResult>();
            var result = _mapper.Map<GetPlanByIdResult>(yearlyPlan);
            var completeUsersAndManagerData = await _planService.CompleteData(yearlyPlan);
            result.UsersManagers = completeUsersAndManagerData.Item1;
            result.Users = completeUsersAndManagerData.Item2;
            return Success(result);
        }

        public async Task<Response<int>> Handle(GetMaxIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _planService.GetMaxId();
            return Success(result);
        }
        #endregion
    }
}
