using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class YearlyPlanReviewRepository : GenericRepositoryAsync<YearlyPlanReview>, IYearlyPlanReviewRepository
    {
        #region Fields
        private DbSet<YearlyPlanReview> _yearlyPlanReviews;
        #endregion

        #region Constructors
        public YearlyPlanReviewRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _yearlyPlanReviews=dbContext.Set<YearlyPlanReview>();
        }
        #endregion
    }
}
