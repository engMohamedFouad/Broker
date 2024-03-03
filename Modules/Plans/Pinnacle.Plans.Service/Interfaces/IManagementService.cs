using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IManagementService
    {
        public IQueryable<Management> GetAll();
        public IQueryable<Management> GetManagementsQuery(string? filter);
        public Task<Management> GetById(int id);
        public Task<bool> AddManagementAsync(Management management);
        public Task<bool> UpdateManagementAsync(Management management);
        public Task<bool> DeleteManagementAsync(Management management);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
    }
}
