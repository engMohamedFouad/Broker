using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class IndicatorsCategoryService : IIndicatorsCategoryService
    {
        #region Fields
        private readonly IIndicatorsCategoryRepository _indicatorsCategoryRepository;
        private readonly ISystemLogService _systemLogService;
        #endregion
        #region Constructors
        public IndicatorsCategoryService(IIndicatorsCategoryRepository indicatorsCategoryRepository,
                                         ISystemLogService systemLogService)
        {
            _indicatorsCategoryRepository = indicatorsCategoryRepository;
            _systemLogService = systemLogService;
        }
        #endregion
        #region Handle Functions
        public async Task<bool> AddIndicatorsCategoryAsync(IndicatorsCategory indicatorsCategory)
        {
            var trans = await _indicatorsCategoryRepository.BeginTransactionAsync();
            try
            {
                await _indicatorsCategoryRepository.AddAsync(indicatorsCategory);


                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = indicatorsCategory.Id,
                    TableAr = "تصنيف مؤشر",
                    TableEn = "Indicator Category",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public async Task<bool> DeleteIndicatorsCategoryAsync(IndicatorsCategory indicatorsCategory)
        {
            var trans = await _indicatorsCategoryRepository.BeginTransactionAsync();
            try
            {
                await _indicatorsCategoryRepository.DeleteAsync(indicatorsCategory);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = indicatorsCategory.Id,
                    TableAr = "تصنيف مؤشر",
                    TableEn = "Indicator Category",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }

        public IQueryable<IndicatorsCategory> GetAll()
        {
            return _indicatorsCategoryRepository.GetTableNoTracking();
        }

        public async Task<IndicatorsCategory> GetById(int id)
        {
            return await _indicatorsCategoryRepository.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<IndicatorsCategory> GetIndicatorsCategorysQuery(string? filter)
        {
            var indicatorsCategory = GetAll();
            if (!string.IsNullOrEmpty(filter))
            {
                indicatorsCategory = indicatorsCategory.Where(x => x.NameAr.Contains(filter) ||
                                                                 x.NameEn.Contains(filter));
            }
            return indicatorsCategory.OrderByDescending(x => x.Id);
        }

        public async Task<bool> IsNameArExist(string nameAr)
        {
            return await GetAll().AnyAsync(x => x.NameAr == nameAr);
        }

        public async Task<bool> IsNameArExistExcludeSelf(string nameAr, int id)
        {
            return await GetAll().AnyAsync(x => x.NameAr == nameAr && x.Id != id);
        }

        public async Task<bool> IsNameEnExist(string nameEn)
        {
            return await GetAll().AnyAsync(x => x.NameEn == nameEn);
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id)
        {
            return await GetAll().AnyAsync(x => x.NameEn == nameEn && x.Id != id);
        }
        public async Task<bool> UpdateIndicatorsCategoryAsync(IndicatorsCategory indicatorsCategory)
        {
            var trans = await _indicatorsCategoryRepository.BeginTransactionAsync();
            try
            {
                await _indicatorsCategoryRepository.UpdateAsync(indicatorsCategory);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = indicatorsCategory.Id,
                    TableAr = "تصنيف مؤشر",
                    TableEn = "Indicator Category",
                });
                await trans.CommitAsync();
                return true;
            }
            catch
            {
                await trans.RollbackAsync();
                return false;
            }
        }
        #endregion
    }
}
