using Broker.AuthenticationAndAuthorization.Core.Features.Authorization.Quaries.Results;
using Broker.Data.Entities.Identity;

namespace Broker.AuthenticationAndAuthorization.Core.Mapping.Roles
{
    public partial class RoleProfile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<Role, GetRoleByIdResult>();
        }
    }
}
