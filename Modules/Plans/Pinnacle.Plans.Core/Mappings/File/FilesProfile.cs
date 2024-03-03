using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.File
{
    public partial class FilesProfile : Profile
    {
        public FilesProfile()
        {
            GetFilesOfPlanMapping();
            GetFileByIdMapping();
            AddFileMapping();
            UpdateFilesMapping();
        }
    }
}
