using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Results;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Models
{
    public class GetReviewTopicsByIdQuery : IRequest<Response<GetReviewTopicsByIdResult>>
    {
        public int Id { get; set; }
    }
}
