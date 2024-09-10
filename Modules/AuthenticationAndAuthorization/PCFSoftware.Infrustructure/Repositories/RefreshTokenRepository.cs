using Broker.AuthenticationAndAuthorization.Infrustructure.Abstracts;
using Broker.Data.Entities.Identity;
using Broker.Infrustructure.Context;
using Broker.Infrustructure.InfrastructureBases;
using Microsoft.EntityFrameworkCore;

namespace Broker.AuthenticationAndAuthorization.Infrustructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {
        #region Fields
        private DbSet<UserRefreshToken> userRefreshToken;
        #endregion

        #region Constructors
        public RefreshTokenRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            userRefreshToken=dbContext.Set<UserRefreshToken>();
        }
        #endregion

        #region Handle Functions

        #endregion
    }
}
