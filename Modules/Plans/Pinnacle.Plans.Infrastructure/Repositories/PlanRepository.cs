using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class PlanRepository : GenericRepositoryAsync<YearlyPlan>, IPlanRepository
    {
        #region Fields
        private DbSet<YearlyPlan> _yearlyPlans;
        #endregion

        #region Constructors
        public PlanRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _yearlyPlans=dbContext.Set<YearlyPlan>();
        }
        #endregion
    }
}
