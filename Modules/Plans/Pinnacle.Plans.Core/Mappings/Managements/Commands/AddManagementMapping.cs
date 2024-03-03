using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Managements.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.Managements
{
    public partial class ManagementProfile
    {
        public void AddManagementMapping()
        {
            CreateMap<AddManagementCommand, Management>();
        }
    }
}
