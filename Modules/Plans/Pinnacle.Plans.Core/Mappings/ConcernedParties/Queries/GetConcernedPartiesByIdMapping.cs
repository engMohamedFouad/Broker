using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Results;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Mappings.ConcernedParties
{
    public partial class ConcernedPartiesProfile
    {
        public void GetConcernedPartiesByIdMapping()
        {
            CreateMap<ConcernedParty, GetConcernedPartiesByIdResult>()
                .ForMember(opt => opt.BranchNames, des => des.MapFrom(src => src.BranchesNavigations));

            CreateMap<Branch, BranchesDTO>()
                .ForMember(opt => opt.Id, des => des.MapFrom(src => src.Id))
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

        }
    }
}
