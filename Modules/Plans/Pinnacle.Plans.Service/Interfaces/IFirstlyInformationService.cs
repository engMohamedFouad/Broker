using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IFirstlyInformationService
    {
        public IQueryable<FirstlyData> GetAll();
        public IQueryable<FirstlyData> GetFirstlyDatasQuery(string? filter);
        public Task<FirstlyData> GetById(int id);
        public Task<bool> AddFirstlyDataAsync(FirstlyData firstlyData);
        public Task<bool> UpdateFirstlyDataAsync(FirstlyData firstlyData);
        public Task<bool> DeleteFirstlyDataAsync(FirstlyData firstlyData);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
    }
}
