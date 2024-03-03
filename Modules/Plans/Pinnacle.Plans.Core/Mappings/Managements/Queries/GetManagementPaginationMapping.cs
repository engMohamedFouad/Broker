using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Managements.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.Managements
{
    public partial class ManagementProfile
    {
        public void GetManagementPaginationMapping()
        {
            CreateMap<Management, GetManagementsResult>()
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                .ForMember(opt => opt.PartyName, des => des.MapFrom(src => src.Localize(src.ConcernedPartyNavigation.NameAr, src.ConcernedPartyNavigation.NameEn)));

        }
    }
}