using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Results;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Models
{
    public class GetReviewPointsQuery : PaginatedRequest, IRequest<PaginatedResult<GetReviewPointsResult>>
    {
    }
}
