using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class ManagementService : IManagementService
    {
        #region Fields
        private readonly IManagementRepository _ManagementRepository;
        private readonly ISystemLogService _systemLogService;
        #endregion
        #region Constructors
        public ManagementService(IManagementRepository ManagementRepository,
                                 ISystemLogService systemLogService)
        {
            _ManagementRepository = ManagementRepository;
            _systemLogService = systemLogService;
        }
        #endregion
        #region Handle Functions
        public async Task<bool> AddManagementAsync(Management management)
        {
            var trans = await _ManagementRepository.BeginTransactionAsync();
            try
            {
                await _ManagementRepository.AddAsync(management);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = management.Id,
                    TableAr = "اداراة",
                    TableEn = "Management",
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

        public async Task<bool> DeleteManagementAsync(Management management)
        {
            var trans = await _ManagementRepository.BeginTransactionAsync();
            try
            {
                await _ManagementRepository.DeleteAsync(management);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = management.Id,
                    TableAr = "اداراة",
                    TableEn = "Management",
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

        public IQueryable<Management> GetAll()
        {
            return _ManagementRepository.GetTableNoTracking();
        }

        public async Task<Management> GetById(int id)
        {
            return await _ManagementRepository.GetTableNoTracking().Include(x => x.ConcernedPartyNavigation).FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Management> GetManagementsQuery(string? filter)
        {
            var managements = GetAll().Include(x => x.ConcernedPartyNavigation).AsQueryable();
            if (!string.IsNullOrEmpty(filter))
            {
                managements = managements.Where(x => x.NameAr.Contains(filter) ||
                                                             x.NameEn.Contains(filter) ||
                                                             x.ConcernedPartyNavigation.NameAr.Contains(filter) ||
                                                             x.ConcernedPartyNavigation.NameEn.Contains(filter));
            }
            return managements.OrderByDescending(x => x.Id);
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

        public async Task<bool> UpdateManagementAsync(Management management)
        {
            var trans = await _ManagementRepository.BeginTransactionAsync();
            try
            {
                await _ManagementRepository.UpdateAsync(management);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = management.Id,
                    TableAr = "اداراة",
                    TableEn = "Management",
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

