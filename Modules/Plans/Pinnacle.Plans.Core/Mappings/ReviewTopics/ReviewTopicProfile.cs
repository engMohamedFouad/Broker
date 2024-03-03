using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.ReviewTopics
{
    public partial class ReviewTopicProfile : Profile
    {
        public ReviewTopicProfile()
        {
            GetReviewTopicMapping();
            GetReviewTopicsByIdMapping();
            AddReviewTopicsMapping();
            UpdateReviewTopicsMapping();
        }
    }
}
