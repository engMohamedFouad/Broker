using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.ReviewTopics
{
    public partial class ReviewTopicProfile
    {
        public void AddReviewTopicsMapping()
        {
            CreateMap<AddReviewTopicsCommand, ReviewTopic>();
        }
    }
}
