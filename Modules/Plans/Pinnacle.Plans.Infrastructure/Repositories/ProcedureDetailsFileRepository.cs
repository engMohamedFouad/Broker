using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class ProcedureDetailsFileRepository : GenericRepositoryAsync<ProcedureDetailFile>, IProcedureDetailsFileRepository
    {
        #region Fields
        public DbSet<ProcedureDetailFile> ProcedureDetailFiles { get; set; }
        #endregion
        #region Constructors
        public ProcedureDetailsFileRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            ProcedureDetailFiles = applicationDBContext.Set<ProcedureDetailFile>();
        }
        #endregion
    }
}
