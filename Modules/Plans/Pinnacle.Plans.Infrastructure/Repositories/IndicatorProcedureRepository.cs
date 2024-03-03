using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class IndicatorProcedureRepository : GenericRepositoryAsync<IndicatorProcedure>, IIndicatorProcedureRepository
    {
        #region Fields
        public DbSet<IndicatorProcedure> IndicatorProcedures { get; set; }
        #endregion
        #region Constructors
        public IndicatorProcedureRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            IndicatorProcedures = applicationDBContext.Set<IndicatorProcedure>();
        }
        #endregion
    }
}
