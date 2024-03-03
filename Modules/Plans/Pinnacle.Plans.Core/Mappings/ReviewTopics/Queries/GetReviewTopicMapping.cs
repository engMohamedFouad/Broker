using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ReviewTopics.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.ReviewTopics
{
    public partial class ReviewTopicProfile
    {
        public void GetReviewTopicMapping()
        {
            CreateMap<ReviewTopic, GetReviewTopicsResult>()
                .ForMember(opt => opt.Description, des => des.MapFrom(src => src.Localize(src.DescriptionAr, src.DescriptionEn)));
        }
    }
}
