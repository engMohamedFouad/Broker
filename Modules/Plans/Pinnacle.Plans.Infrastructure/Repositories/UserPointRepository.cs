using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class UserPointRepository : GenericRepositoryAsync<UserPoint>, IUserPointRepository
    {
        #region Fields
        private DbSet<UserPoint> _users;
        #endregion
        #region Constructors
        public UserPointRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            _users = applicationDBContext.Set<UserPoint>();
        }
        #endregion
    }
}
