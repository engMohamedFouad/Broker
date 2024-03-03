using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class FirstlyInformationRepository : GenericRepositoryAsync<FirstlyData>, IFirstlyInformationRepository
    {
        #region Fields
        private DbSet<FirstlyData> _firstlyDatas;
        #endregion

        #region Constructors
        public FirstlyInformationRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _firstlyDatas=dbContext.Set<FirstlyData>();
        }
        #endregion
    }
}
