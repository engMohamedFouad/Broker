using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class YearlyPlanManagementRepository : GenericRepositoryAsync<YearlyPlanManagement>, IYearlyPlanManagementRepository
    {
        #region Fields
        private DbSet<YearlyPlanManagement> _yearlyPlanManagements;
        #endregion

        #region Constructors
        public YearlyPlanManagementRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _yearlyPlanManagements=dbContext.Set<YearlyPlanManagement>();
        }
        #endregion
    }
}

