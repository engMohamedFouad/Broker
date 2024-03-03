using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Reviews.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.Reviews
{
    public partial class ReviewProfile
    {
        public void GetReviewByIdMapping()
        {
            CreateMap<Review, GetReviewByIdResult>();
        }
    }
}
