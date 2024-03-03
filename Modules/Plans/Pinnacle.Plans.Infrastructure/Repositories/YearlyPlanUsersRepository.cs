using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class YearlyPlanUsersRepository : GenericRepositoryAsync<YearlyPlanUsers>, IYearlyPlanUsersRepository
    {
        #region Fields
        private DbSet<YearlyPlanUsers> _yearlyPlanUsers;
        #endregion

        #region Constructors
        public YearlyPlanUsersRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _yearlyPlanUsers=dbContext.Set<YearlyPlanUsers>();
        }
        #endregion
    }
}

