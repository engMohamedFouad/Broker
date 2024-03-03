using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class BranchRepository : GenericRepositoryAsync<Branch>, IBranchRepository
    {
        #region Fields
        public DbSet<Branch> Branches { get; set; }
        #endregion
        #region Constructors
        public BranchRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            Branches = applicationDBContext.Set<Branch>();
        }
        #endregion
    }
}
