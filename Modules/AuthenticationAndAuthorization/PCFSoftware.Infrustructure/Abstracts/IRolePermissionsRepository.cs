using Broker.Data.Entities.Identity;
using Broker.Infrustructure.InfrastructureBases;

namespace Broker.AuthenticationAndAuthorization.Infrustructure.Abstracts
{
    public interface IRolePermissionsRepository : IGenericRepositoryAsync<RolePermissions>
    {
    }
}
