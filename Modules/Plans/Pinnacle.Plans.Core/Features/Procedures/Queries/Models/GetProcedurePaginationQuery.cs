using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Procedures.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Procedures.Queries.Models
{
    public class GetProcedurePaginationQuery : PaginatedRequest, IRequest<PaginatedResult<GetProcedurePaginationResult>>
    {
    }
}
