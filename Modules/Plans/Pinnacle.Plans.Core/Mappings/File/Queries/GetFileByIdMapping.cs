using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.File.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.File
{
    public partial class FilesProfile
    {
        public void GetFileByIdMapping()
        {
            CreateMap<Files, GetFileByIdResult>();
        }
    }
}
