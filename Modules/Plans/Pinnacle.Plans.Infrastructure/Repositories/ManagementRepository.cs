using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class ManagementRepository : GenericRepositoryAsync<Management>, IManagementRepository
    {
        #region Fields
        private DbSet<Management> _management;
        #endregion

        #region Constructors
        public ManagementRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _management=dbContext.Set<Management>();
        }
        #endregion
    }
}
