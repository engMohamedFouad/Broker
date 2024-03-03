using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class SystemLogRepository : GenericRepositoryAsync<SystemLog>, ISystemLogRepository
    {
        #region Fields
        private DbSet<SystemLog> _systemLogs;
        #endregion

        #region Constructors
        public SystemLogRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _systemLogs=dbContext.Set<SystemLog>();
        }
        #endregion
    }
}
