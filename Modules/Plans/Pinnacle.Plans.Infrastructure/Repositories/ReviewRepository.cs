using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class ReviewRepository : GenericRepositoryAsync<Review>, IReviewRepository
    {
        #region Fields
        private DbSet<Review> _reviews;
        #endregion

        #region Constructors
        public ReviewRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _reviews=dbContext.Set<Review>();
        }
        #endregion
    }
}
