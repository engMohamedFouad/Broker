using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class ProcedureRepository : GenericRepositoryAsync<Procedure>, IProcedureRepository
    {
        #region Fields
        public DbSet<Procedure> Procedures { get; set; }
        #endregion
        #region Constructors
        public ProcedureRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            Procedures = applicationDBContext.Set<Procedure>();
        }
        #endregion
    }
}
