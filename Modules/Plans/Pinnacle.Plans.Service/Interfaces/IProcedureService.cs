using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IProcedureService
    {
        public IQueryable<Procedure> GetAll();
        public IQueryable<Procedure> GetProceduresQuery(string? filter);
        public Task<Procedure> GetById(int id);
        public Task<bool> AddProcedureAsync(Procedure procedure, int? indicatorId, int? PlanId);
        public Task<bool> UpdateProcedureAsync(Procedure procedure);
        public Task<bool> DeleteProcedureAsync(Procedure procedure);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
    }
}
