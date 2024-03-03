//using Microsoft.EntityFrameworkCore;
//using Pinnacle.Data.Entities.BasicData;
//using Pinnacle.Infrustructure.Context;
//using Pinnacle.Infrustructure.InfrastructureBases;
//using Pinnacle.Plans.Infrastructure.Abstracts;

//namespace Pinnacle.Plans.Infrastructure.Repositories
//{
//    public class IndicatorDetailsRepository : GenericRepositoryAsync<IndicatorDetails>, IIndicatorDetailsRepository
//    {
//        #region Fields
//        private DbSet<IndicatorDetails> _indicatorDetails;
//        #endregion

//        #region Constructors
//        public IndicatorDetailsRepository(ApplicationDBContext dbContext) : base(dbContext)
//        {
//            _indicatorDetails=dbContext.Set<IndicatorDetails>();
//        }
//        #endregion
//    }
//}
