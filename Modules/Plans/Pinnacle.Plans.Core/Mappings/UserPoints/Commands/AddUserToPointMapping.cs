using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.UserPoints.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.UserPoints
{
    public partial class UserPointProfile
    {
        public void AddUserToPointMapping()
        {
            CreateMap<AddUserPointCommand, UserPoint>()
                .ForMember(opt => opt.UId, des => des.MapFrom(src => src.UserId))
                .ForMember(opt => opt.PId, des => des.MapFrom(src => src.PointId));
        }

    }
}
