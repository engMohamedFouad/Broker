using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Models;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Handlers
{
    public class ProcedureDetailsQueryHandler : ResponseHandler,
        IRequestHandler<GetProcedureDetailsPaginationQuery, PaginatedResult<GetProcedureDetailsPaginationResult>>,
        IRequestHandler<GetProcedureDetailsByIdQuery, Response<GetProcedureDetailsByIdResult>>
    {
        #region Fields
        private readonly IProcedureDetailsService _procedureDetailservice;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ProcedureDetailsQueryHandler(IProcedureDetailsService procedureDetailservice,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _procedureDetailservice = procedureDetailservice;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetProcedureDetailsPaginationResult>> Handle(GetProcedureDetailsPaginationQuery request, CancellationToken cancellationToken)
        {
            var query = await _procedureDetailservice.GetProcedureDetailsQuery(request.Search, request.PlanId, request.IndicatorId);
            if (query == null)
            {
                var response = new PaginatedResult<GetProcedureDetailsPaginationResult>(null);
                return response;
            }
            var result = await _mapper.ProjectTo<GetProcedureDetailsPaginationResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetProcedureDetailsByIdResult>> Handle(GetProcedureDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var management = await _procedureDetailservice.GetByIdAsync(request.Id);
            if (management == null) return NotFound<GetProcedureDetailsByIdResult>();
            var result = _mapper.Map<GetProcedureDetailsByIdResult>(management);
            return Success(result);
        }

        #endregion
    }
}