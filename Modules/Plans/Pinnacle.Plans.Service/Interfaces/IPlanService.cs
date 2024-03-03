using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IPlanService
    {
        public IQueryable<YearlyPlan> GetAll();
        public IQueryable<YearlyPlan> GetyearlyPlansQuery(string? year, string? concernedParty, string? employeeName, bool status);
        public Task<YearlyPlan> GetById(int id);
        public Task<YearlyPlan> GetByIdWithoutInclude(int id);
        public Task<int> GetMaxId();
        public Task<bool> AddYearlyPlanAsync(YearlyPlan yearlyPlan, List<AddUserManagersDTO> userManagers);
        public Task<bool> UpdateYearlyPlanAsync(YearlyPlan yearlyPlan, AddPlansDTO addPlansDTO);
        public Task<bool> DeleteYearlyPlanAsync(YearlyPlan yearlyPlan);

        public Task<(List<UserManagersDTO>, List<UserDTO>)> CompleteData(YearlyPlan yearlyPlan);
    }
}
