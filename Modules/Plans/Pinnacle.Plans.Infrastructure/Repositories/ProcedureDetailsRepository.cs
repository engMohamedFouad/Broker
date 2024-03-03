using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class ProcedureDetailsRepository : GenericRepositoryAsync<ProcedureDetails>, IProcedureDetailsRepository
    {
        #region Fields
        public DbSet<ProcedureDetails> ProceduresDetails { get; set; }
        #endregion
        #region Constructors
        public ProcedureDetailsRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            ProceduresDetails = applicationDBContext.Set<ProcedureDetails>();
        }
        #endregion
    }
}
