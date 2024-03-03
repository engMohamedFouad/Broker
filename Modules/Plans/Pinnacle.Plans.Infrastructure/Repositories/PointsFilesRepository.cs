using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class PointsFilesRepository : GenericRepositoryAsync<PointsFiles>, IPointsFilesRepository
    {
        #region Fields
        public DbSet<PointsFiles> PointsFiles { get; set; }
        #endregion
        #region Constructors
        public PointsFilesRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            PointsFiles = applicationDBContext.Set<PointsFiles>();
        }
        #endregion
    }
}
