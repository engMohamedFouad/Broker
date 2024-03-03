using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Infrustructure.Context;
using Pinnacle.Infrustructure.InfrastructureBases;
using Pinnacle.Plans.Infrastructure.Abstracts;

namespace Pinnacle.Plans.Infrastructure.Repositories
{
    public class PhoneNumbersRepository : GenericRepositoryAsync<PhoneNumber>, IPhoneNumbersRepository
    {
        #region Fields
        private DbSet<PhoneNumber> _phoneNumbers;
        #endregion
        #region Constructors
        public PhoneNumbersRepository(ApplicationDBContext dbContext) : base(dbContext)
        {
            _phoneNumbers=dbContext.Set<PhoneNumber>();
        }
        #endregion
    }
}
