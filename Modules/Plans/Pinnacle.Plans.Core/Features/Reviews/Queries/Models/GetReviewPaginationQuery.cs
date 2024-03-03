using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Reviews.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Reviews.Queries.Models
{
    public class GetReviewPaginationQuery : IRequest<PaginatedResult<GetReviewPaginationResult>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
