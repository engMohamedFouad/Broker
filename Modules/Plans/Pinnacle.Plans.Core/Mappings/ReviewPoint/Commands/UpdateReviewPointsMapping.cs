using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.ReviewPoint
{
    public partial class ReviewPointsProfile
    {
        public void UpdateReviewPointsMapping()
        {
            CreateMap<UpdateReviewPointsCommand, ReviewPoints>();
        }
    }
}
