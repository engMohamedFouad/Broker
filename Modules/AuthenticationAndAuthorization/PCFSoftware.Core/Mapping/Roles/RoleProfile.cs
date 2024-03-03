using AutoMapper;

namespace Broker.AuthenticationAndAuthorization.Core.Mapping.Roles
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            GetRolesListMapping();
            GetRoleByIdMapping();
        }
    }
}
