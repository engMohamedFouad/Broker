using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Results;

namespace Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Models
{
    public class GetProcedureDetailsPaginationQuery : PaginatedRequest, IRequest<PaginatedResult<GetProcedureDetailsPaginationResult>>
    {
        public int PlanId { get; set; }
        public int IndicatorId { get; set; }
    }
}
