using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IIndicatorsCategoryService
    {
        public IQueryable<IndicatorsCategory> GetAll();
        public IQueryable<IndicatorsCategory> GetIndicatorsCategorysQuery(string? filter);
        public Task<IndicatorsCategory> GetById(int id);
        public Task<bool> AddIndicatorsCategoryAsync(IndicatorsCategory indicatorsCategory);
        public Task<bool> UpdateIndicatorsCategoryAsync(IndicatorsCategory indicatorsCategory);
        public Task<bool> DeleteIndicatorsCategoryAsync(IndicatorsCategory indicatorsCategory);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
    }
}
