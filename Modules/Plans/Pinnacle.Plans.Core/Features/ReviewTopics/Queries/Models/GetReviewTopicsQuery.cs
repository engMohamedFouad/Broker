using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Results;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Models
{
    public class GetReviewTopicsQuery : IRequest<PaginatedResult<GetReviewTopicsResult>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
