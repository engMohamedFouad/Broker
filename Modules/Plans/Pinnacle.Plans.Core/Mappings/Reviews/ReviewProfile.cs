using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.Reviews
{
    public partial class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            GetReviewPaginationMapping();
            GetReviewByIdMapping();
            AddReviewMapping();
            UpdateReviewMapping();
        }
    }
}
