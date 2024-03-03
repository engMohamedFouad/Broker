using Pinnacle.Data.Entities.BasicData;

namespace Pinnacle.Plans.Service.Interfaces
{
    public interface IBranchService
    {
        public IQueryable<Branch> GetBranchesbyConcernedParty(string? search, int concernedPartyId);
    }
}
