using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Reviews.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.Reviews
{
    public partial class ReviewProfile
    {
        public void GetReviewPaginationMapping()
        {
            CreateMap<Review, GetReviewPaginationResult>()
                .ForMember(opt => opt.Type, des => des.MapFrom(src => src.Localize(src.TypeAr, src.TypeEn)));
        }
    }
}
