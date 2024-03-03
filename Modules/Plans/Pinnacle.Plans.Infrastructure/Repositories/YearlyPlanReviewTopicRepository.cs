using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class YearlyPlanReviewTopicRepository : GenericRepositoryAsync<YearlyPlanReviewTopic>, IYearlyPlanReviewTopicRepository
    {
        #region Fields
        private DbSet<YearlyPlanReviewTopic> _yearlyPlanReviewTopics;
        #endregion

        #region Constructors
        public YearlyPlanReviewTopicRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _yearlyPlanReviewTopics=dbContext.Set<YearlyPlanReviewTopic>();
        }
        #endregion
    }
}
