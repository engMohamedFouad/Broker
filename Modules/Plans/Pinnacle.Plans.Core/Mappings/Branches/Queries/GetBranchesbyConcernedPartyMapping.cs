using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Branches.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.Branches
{
    public partial class BranchProfile
    {
        public void GetBranchesbyConcernedPartyMapping()
        {
            CreateMap<Branch, GetBranchesByConcernedPartyResult>()
                    .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
