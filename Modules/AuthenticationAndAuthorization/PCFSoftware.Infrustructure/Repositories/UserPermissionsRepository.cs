using Microsoft.EntityFrameworkCore;
using Broker.AuthenticationAndAuthorization.Infrustructure.Abstracts;
using Broker.Data.Entities.Identity;
using Broker.Infrustructure.Context;
using Broker.Infrustructure.InfrastructureBases;

namespace Broker.AuthenticationAndAuthorization.Infrustructure.Repositories
{
    public class UserPermissionsRepository : GenericRepositoryAsync<UserPermissions>, IUserPermissionsRepository
    {
        #region Fields
        private DbSet<UserPermissions> UserPermissions { get; set; }
        #endregion
        #region Constructor
        public UserPermissionsRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            UserPermissions = applicationDBContext.Set<UserPermissions>();
        }
        #endregion
    }
}
