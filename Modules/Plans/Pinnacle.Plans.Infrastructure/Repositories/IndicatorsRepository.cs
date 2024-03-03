using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class IndicatorsRepository : GenericRepositoryAsync<Indicator>, IIndicatorsRepository
    {
        #region Fields
        private DbSet<Indicator> _indicators;
        #endregion

        #region Constructors
        public IndicatorsRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _indicators=dbContext.Set<Indicator>();
        }
        #endregion
    }
}