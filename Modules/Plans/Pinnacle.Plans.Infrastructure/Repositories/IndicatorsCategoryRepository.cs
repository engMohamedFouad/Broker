using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class IndicatorsCategoryRepository : GenericRepositoryAsync<IndicatorsCategory>, IIndicatorsCategoryRepository
    {
        #region Fields
        private DbSet<IndicatorsCategory> _indicatorsCategories;
        #endregion

        #region Constructors
        public IndicatorsCategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _indicatorsCategories=dbContext.Set<IndicatorsCategory>();
        }
        #endregion
    }
}
