using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.FirstlyInformation
{
    public partial class FirstlyDataProfile : Profile
    {
        public FirstlyDataProfile()
        {
            GetFirstlyDataMapping();
            GetFirstlyDataByIdMapping();
            AddFirstlyDataMapping();
            UpdateFirstlyDataCommand();
        }
    }
}
