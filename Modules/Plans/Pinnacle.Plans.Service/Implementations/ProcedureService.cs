using Microsoft.EntityFrameworkCore;
using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Data.Enums;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class ProcedureService : IProcedureService
    {
        #region Fields
        private readonly IProcedureRepository _procedureRepository;
        private readonly ISystemLogService _systemLogService;
        private readonly IIndicatorProcedureRepository _indicatorProcedureRepository;
        #endregion
        #region Constructors
        public ProcedureService(IProcedureRepository procedureRepository,
                                ISystemLogService systemLogService,
                                IIndicatorProcedureRepository indicatorProcedureRepository)
        {
            _procedureRepository = procedureRepository;
            _systemLogService = systemLogService;
            _indicatorProcedureRepository = indicatorProcedureRepository;

        }
        #endregion
        #region Handle Functions

        public async Task<bool> AddProcedureAsync(Procedure procedure, int? indicatorId, int? PlanId)
        {
            var trans = await _procedureRepository.BeginTransactionAsync();
            try
            {
                await _procedureRepository.AddAsync(procedure);
                //If the Procedure is from Indicator Page then set the Indicator
                if (indicatorId != null)
                {
                    await _indicatorProcedureRepository.AddAsync(new IndicatorProcedure() { IndicatorId = (int)indicatorId, PlanId = (int)PlanId, ProcedureId = procedure.Id });
                }

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Add,
                    ItemId = procedure.Id,
                    TableAr = "اجراء",
                    TableEn = "Procedure",
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

        public async Task<bool> DeleteProcedureAsync(Procedure procedure)
        {
            var trans = await _procedureRepository.BeginTransactionAsync();
            try
            {
                await _procedureRepository.DeleteAsync(procedure);
                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Delete,
                    ItemId = procedure.Id,
                    TableAr = "اجراء",
                    TableEn = "Procedure",
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

        public IQueryable<Procedure> GetAll()
        {
            return _procedureRepository.GetTableNoTracking();
        }

        public async Task<Procedure> GetById(int id)
        {
            return await _procedureRepository.GetByIdAsync(id);
        }

        public IQueryable<Procedure> GetProceduresQuery(string? filter)
        {
            var procedures = GetAll();
            if (!string.IsNullOrEmpty(filter))
            {
                procedures = procedures.Where(x => x.NameAr.Contains(filter) ||
                                                   x.NameEn.Contains(filter));
            }
            return procedures.OrderByDescending(x => x.Id);
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

        public async Task<bool> UpdateProcedureAsync(Procedure procedure)
        {
            var trans = await _procedureRepository.BeginTransactionAsync();
            try
            {
                await _procedureRepository.UpdateAsync(procedure);

                //Added logs
                await _systemLogService.AddSystemLog(new SystemLog()
                {
                    OperationId = (int)SystemOperationsEnum.Update,
                    ItemId = procedure.Id,
                    TableAr = "اجراء",
                    TableEn = "Procedure",
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
