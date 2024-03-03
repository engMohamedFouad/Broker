using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.UserPoints.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.UserPoints
{
    public partial class UserPointProfile
    {
        public void GetUsersByPointIdMapping()
        {
            CreateMap<UserPoint, GetUsersAssignedByPointIdResult>()
                .ForMember(opt => opt.UserId, des => des.MapFrom(src => src.UId))
                .ForMember(opt => opt.UserName, des => des.MapFrom(src => src.UserNavigation.UserName))
                .ForMember(opt => opt.PointId, des => des.MapFrom(src => src.PId));
        }
    }
}