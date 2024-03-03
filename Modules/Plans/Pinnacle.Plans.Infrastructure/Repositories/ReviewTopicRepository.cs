using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class ReviewTopicRepository : GenericRepositoryAsync<ReviewTopic>, IReviewTopicRepository
    {
        #region Fields
        private DbSet<ReviewTopic> _reviewTopics;
        #endregion

        #region Constructors
        public ReviewTopicRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _reviewTopics=dbContext.Set<ReviewTopic>();
        }
        #endregion
    }
}
