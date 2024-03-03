using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.ConcernedParties.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.ConcernedParties
{
    public partial class ConcernedPartiesProfile
    {
        public void UpdateConcernedPartiesMapping()
        {
            CreateMap<UpdateConcernedPartiesCommand, ConcernedParty>();
        }
    }
}
