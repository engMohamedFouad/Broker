using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class YearlyPlanBranchRepository : GenericRepositoryAsync<YearlyPlanBranch>, IYearlyPlanBranchRepository
    {
        #region Fields
        public DbSet<YearlyPlanBranch> YearlyPlanBranches { get; set; }
        #endregion
        #region Constructors
        public YearlyPlanBranchRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            YearlyPlanBranches = applicationDBContext.Set<YearlyPlanBranch>();
        }
        #endregion
    }
}
