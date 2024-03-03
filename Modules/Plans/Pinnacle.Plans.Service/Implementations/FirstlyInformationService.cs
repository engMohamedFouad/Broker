using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class FirstlyInformationService : IFirstlyInformationService
    {
        #region Fields
        private readonly IFirstlyInformationRepository _firstlyInformationRepository;
        private readonly ISystemLogService _systemLogService;
        #endregion
        #region Constructors
        public FirstlyInformationService(IFirstlyInformationRepository firstlyInformationRepository,
                                         ISystemLogService systemLogService)
        {
            _firstlyInformationRepository = firstlyInformationRepository;
            _systemLogService = systemLogService;

        }
        #endregion
        #region Handle Functions
        public async Task<bool> AddFirstlyDataAsync(FirstlyData firstlyData)
        {
            var trans = await _firstlyInformationRepository.BeginTransactionAsync();
            try
            {
                await _firstlyInformationRepository.AddAsync(firstlyData);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = firstlyData.Id,
                    TableAr = "بيانات اولية",
                    TableEn = "Firstly Data",
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

        public async Task<bool> DeleteFirstlyDataAsync(FirstlyData firstlyData)
        {
            var trans = await _firstlyInformationRepository.BeginTransactionAsync();
            try
            {
                await _firstlyInformationRepository.DeleteAsync(firstlyData);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = firstlyData.Id,
                    TableAr = "بيانات اولية",
                    TableEn = "Firstly Data",
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

        public IQueryable<FirstlyData> GetAll()
        {
            return _firstlyInformationRepository.GetTableNoTracking();
        }

        public async Task<FirstlyData> GetById(int id)
        {
            return await _firstlyInformationRepository.GetTableNoTracking().Include(x => x.ReviewNavigation).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<FirstlyData> GetFirstlyDatasQuery(string? filter)
        {
            var firstlyInformation = GetAll().Include(x => x.ReviewNavigation);
            if (!string.IsNullOrEmpty(filter))
            {
                firstlyInformation = (IIncludableQueryable<FirstlyData, Review?>)firstlyInformation.Where(x => x.DescriptionAr.Contains(filter) ||
                                                                                                             x.DescriptionEn.Contains(filter) ||
                                                                                                             x.ReviewNavigation.TypeAr.Contains(filter) ||
                                                                                                             x.ReviewNavigation.TypeEn.Contains(filter));
            }
            return firstlyInformation.OrderByDescending(x => x.Id);
        }

        public async Task<bool> IsNameArExist(string descriptionAr)
        {
            return await GetAll().AnyAsync(x => x.DescriptionAr == descriptionAr);
        }

        public async Task<bool> IsNameArExistExcludeSelf(string descriptionAr, int id)
        {
            return await GetAll().AnyAsync(x => x.DescriptionAr == descriptionAr && x.Id != id);
        }

        public async Task<bool> IsNameEnExist(string descriptionEn)
        {
            return await GetAll().AnyAsync(x => x.DescriptionEn == descriptionEn);
        }

        public async Task<bool> IsNameEnExistExcludeSelf(string descriptionEn, int id)
        {
            return await GetAll().AnyAsync(x => x.DescriptionEn == descriptionEn && x.Id != id);
        }

        public async Task<bool> UpdateFirstlyDataAsync(FirstlyData firstlyData)
        {
            var trans = await _firstlyInformationRepository.BeginTransactionAsync();
            try
            {
                await _firstlyInformationRepository.UpdateAsync(firstlyData);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = firstlyData.Id,
                    TableAr = "بيانات اولية",
                    TableEn = "Firstly Data",
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
