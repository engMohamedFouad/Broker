using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.FirstlyInformation
{
    public partial class FirstlyDataProfile
    {
        public void AddFirstlyDataMapping()
        {
            CreateMap<AddFirstlyDataCommand, FirstlyData>();
        }
    }
}
