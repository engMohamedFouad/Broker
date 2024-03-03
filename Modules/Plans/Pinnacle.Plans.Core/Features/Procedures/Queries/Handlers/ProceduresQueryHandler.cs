using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using Pinnacle.Core.Bases;
using Pinnacle.Core.Resources;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Procedures.Queries.Models;
using Pinnacle.Plans.Core.Features.Procedures.Queries.Results;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Core.Features.Procedures.Queries.Handlers
{
    public class ProceduresQueryHandler : ResponseHandler,
        IRequestHandler<GetProcedurePaginationQuery, PaginatedResult<GetProcedurePaginationResult>>,
        IRequestHandler<GetProcedureByIdQuery, Response<GetProcedureByIdResult>>
    {
        #region Fields
        private readonly IProcedureService _procedureService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        #endregion
        #region Constructors
        public ProceduresQueryHandler(IProcedureService procedureService,
                                       IMapper mapper,
                                       IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _procedureService = procedureService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        #endregion
        #region Handle Functions
        public async Task<PaginatedResult<GetProcedurePaginationResult>> Handle(GetProcedurePaginationQuery request, CancellationToken cancellationToken)
        {
            var query = _procedureService.GetProceduresQuery(request.Search);
            var result = await _mapper.ProjectTo<GetProcedurePaginationResult>(query).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return result;
        }

        public async Task<Response<GetProcedureByIdResult>> Handle(GetProcedureByIdQuery request, CancellationToken cancellationToken)
        {
            var Procedure = await _procedureService.GetById(request.Id);
            if (Procedure == null) return NotFound<GetProcedureByIdResult>();
            var result = _mapper.Map<GetProcedureByIdResult>(Procedure);
            return Success(result);
        }

        #endregion
    }
}
