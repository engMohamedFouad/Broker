using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IIndicatorService
    {
        public IQueryable<Indicator> GetAll();
        public IQueryable<Indicator> GetIndicatorsQuery(string? filter);
        public Task<Indicator> GetById(int id);
        public Task<GetIndicatorByIdDTO> GetIndicatorAndDetailsAsync(int id);
        public Task<bool> AddIndicatorAsync(Indicator indicator);
        public Task<bool> UpdateIndicatorAsync(Indicator indicator);
        public Task<bool> DeleteIndicatorAsync(Indicator indicator);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<bool> IsExist(int id);
    }
}
