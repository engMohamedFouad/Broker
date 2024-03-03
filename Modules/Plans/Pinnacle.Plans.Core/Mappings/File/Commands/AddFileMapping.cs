using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.File.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.File
{
    public partial class FilesProfile
    {
        public void AddFileMapping()
        {
            CreateMap<AddFilesToPlanCommand, Files>();
        }
    }
}
