using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class PointCommentsRepository : GenericRepositoryAsync<PointsComments>, IPointCommentsRepository
    {
        #region Fields
        public DbSet<PointsComments> PointComments { get; set; }
        #endregion
        #region Constructors
        public PointCommentsRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            PointComments = applicationDBContext.Set<PointsComments>();
        }
        #endregion
    }
}
