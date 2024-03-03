using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.UserPoints
{
    public partial class UserPointProfile : Profile
    {
        public UserPointProfile()
        {
            GetUsersByPointIdMapping();
            AddUserToPointMapping();
        }
    }
}
