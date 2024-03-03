using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.PointComments.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.PointComments
{
    public partial class PointsCommentsProfile
    {
        public void GetPointsCommentsByIdMapping()
        {
            CreateMap<PointsComments, GetPointsCommentsByIdResult>()
               .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.UserNavigation.UserName));
        }
    }
}
