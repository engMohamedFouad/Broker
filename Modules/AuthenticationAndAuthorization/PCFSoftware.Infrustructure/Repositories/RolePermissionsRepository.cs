using Broker.AuthenticationAndAuthorization.Infrustructure.Abstracts;
using Broker.Data.Entities.Identity;
using Broker.Infrustructure.Context;
using Broker.Infrustructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Broker.AuthenticationAndAuthorization.Infrustructure.Repositories
{
    public class RolePermissionsRepository : GenericRepositoryAsync<RolePermissions>, IRolePermissionsRepository
    {
        #region Fields
        private DbSet<RolePermissions> _roles;
        #endregion
        #region Constructors
        public RolePermissionsRepository(ApplicationDbContext applicationDBContext) : base(applicationDBContext)
        {
            _roles = applicationDBContext.Set<RolePermissions>();
        }
        #endregion
    }
}
