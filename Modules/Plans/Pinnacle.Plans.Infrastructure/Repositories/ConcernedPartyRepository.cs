using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class ConcernedPartyRepository : GenericRepositoryAsync<ConcernedParty>, IConcernedPartyRepository
    {
        #region Fields
        private DbSet<ConcernedParty> _concernedParties;
        #endregion

        #region Constructors
        public ConcernedPartyRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _concernedParties=dbContext.Set<ConcernedParty>();
        }
        #endregion
    }
}
