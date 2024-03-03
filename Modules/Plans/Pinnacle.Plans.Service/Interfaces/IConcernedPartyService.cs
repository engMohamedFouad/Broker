using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IConcernedPartyService
    {
        public IQueryable<ConcernedParty> GetAll();
        public IQueryable<ConcernedParty> GetConcernedPartiesQuery(string? filter);
        public Task<ConcernedParty> GetById(int id);
        public Task<int> GetMaxIdAsync();
        public Task<bool> AddConcernedPartyAsync(ConcernedParty concernedParty, List<string> phoneNumbers, List<string>? branchNames);
        public Task<bool> UpdateConcernedPartyAsync(ConcernedParty concernedParty, List<string> phoneNumbers, List<string>? branchNames);
        public Task<bool> DeleteConcernedPartyAsync(ConcernedParty concernedParty);
        public Task<bool> IsNameArExist(string nameAr);
        public Task<bool> IsNameArExistExcludeSelf(string nameAr, int id);
        public Task<bool> IsNameEnExist(string nameEn);
        public Task<bool> IsNameEnExistExcludeSelf(string nameEn, int id);
        public Task<bool> HasManagement(int id);
        public Task<bool> IsExist(int id);
        public Task<List<string>> GetPhoneNumbers(int id);
        public Task<ConcernedParty> GetByIdWithoutIncluding(int id);
    }
}
