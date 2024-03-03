using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.ReviewTopics
{
    public partial class ReviewTopicProfile
    {
        public void GetReviewTopicsByIdMapping()
        {
            CreateMap<ReviewTopic, GetReviewTopicsByIdResult>();
        }
    }
}
