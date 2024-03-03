using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.ConcernedParties
{
    public partial class ConcernedPartiesProfile
    {
        public void GetConcernedPartiesPaginationMapping()
        {
            CreateMap<ConcernedParty, GetConcernedPartiesPaginationResult>()
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
