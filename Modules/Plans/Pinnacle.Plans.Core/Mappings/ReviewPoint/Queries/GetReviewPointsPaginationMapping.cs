using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.ReviewPoint
{
    public partial class ReviewPointsProfile
    {
        public void GetReviewPointsPaginationMapping()
        {
            CreateMap<ReviewPoints, GetReviewPointsResult>()
                 .ForMember(opt => opt.UserName, des => des.MapFrom(src => src.UserNavigation.UserName))
                 .ForMember(opt => opt.IndicatorCode, des => des.MapFrom(src => src.IndicatorNavigation.Code));
        }
    }
}
