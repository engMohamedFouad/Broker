using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Reviews.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.Reviews
{
    public partial class ReviewProfile
    {
        public void UpdateReviewMapping()
        {
            CreateMap<UpdateReviewCommand, Review>();
        }
    }
}
