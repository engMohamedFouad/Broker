using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class ReviewPointsRepository : GenericRepositoryAsync<ReviewPoints>, IReviewPointsRepository
    {
        #region Fields
        public DbSet<ReviewPoints> ReviewPoints { get; set; }
        #endregion
        #region Constructors
        public ReviewPointsRepository(ApplicationDBContext applicationDBContext) : base(applicationDBContext)
        {
            ReviewPoints = applicationDBContext.Set<ReviewPoints>();
        }
        #endregion
    }
}
