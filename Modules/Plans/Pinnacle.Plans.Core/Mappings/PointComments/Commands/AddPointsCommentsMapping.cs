using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.PointComments.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.PointComments
{
    public partial class PointsCommentsProfile
    {
        public void AddPointsCommentsMapping()
        {
            CreateMap<AddPointCommentsCommand, PointsComments>();
        }
    }

}
