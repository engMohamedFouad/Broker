using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.Branches
{
    public partial class BranchProfile : Profile
    {
        public BranchProfile()
        {
            GetBranchesbyConcernedPartyMapping();
        }
    }
}
