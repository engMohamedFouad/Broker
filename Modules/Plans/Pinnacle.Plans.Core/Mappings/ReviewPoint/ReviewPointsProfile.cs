using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.ReviewPoint
{
    public partial class ReviewPointsProfile : Profile
    {
        public ReviewPointsProfile()
        {
            GetReviewPointsPaginationMapping();
            GetReviewPointByIdMapping();
            AddReviewPointsMapping();
            UpdateReviewPointsMapping();
        }
    }
}
