using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Results;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Models
{
    public class GetConcernedPartiesPaginationQuery : IRequest<PaginatedResult<GetConcernedPartiesPaginationResult>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
