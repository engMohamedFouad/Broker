using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.ConcernedParties
{
    public partial class ConcernedPartiesProfile
    {
        public void AddConcernedPartiesMapping()
        {
            CreateMap<AddConcernedPartiesCommand, ConcernedParty>()
                .ForMember(opt => opt.Id, des => des.Ignore());
        }
    }
}
