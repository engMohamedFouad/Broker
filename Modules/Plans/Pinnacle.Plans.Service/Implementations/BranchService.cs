using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Infrastructure.Abstracts;
using Pinnacle.Plans.Service.Interfaces;

namespace Pinnacle.Plans.Service.Implementations
{
    public class BranchService : IBranchService
    {
        #region Fields
        private readonly IBranchRepository _branchRepository;
        #endregion
        #region Constructors
        public BranchService(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }
        #endregion
        #region Handle Functions
        public IQueryable<Branch> GetBranchesbyConcernedParty(string? search, int concernedPartyId)
        {
            var branches = _branchRepository.GetTableNoTracking().Where(x => x.ConcernedPartyId == concernedPartyId);
            if (search != null)
            {
                branches = branches.Where(x => x.NameAr.Contains(search) || x.NameEn.Contains(search));
            }
            return branches.OrderByDescending(x => x.Id);
        }
        #endregion
    }
}
