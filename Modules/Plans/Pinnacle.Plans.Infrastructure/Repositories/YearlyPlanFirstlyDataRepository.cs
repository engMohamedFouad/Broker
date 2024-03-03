using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class YearlyPlanFirstlyDataRepository : GenericRepositoryAsync<YearlyPlanFirstlyData>, IYearlyPlanFirstlyDataRepository
    {
        #region Fields
        private DbSet<YearlyPlanFirstlyData> _yearlyPlanFirstlyDatas;
        #endregion

        #region Constructors
        public YearlyPlanFirstlyDataRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _yearlyPlanFirstlyDatas=dbContext.Set<YearlyPlanFirstlyData>();
        }
        #endregion
    }
}
