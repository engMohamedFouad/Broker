using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.FirstlyInformation
{
    public partial class FirstlyDataProfile
    {
        public void GetFirstlyDataMapping()
        {
            CreateMap<FirstlyData, GetFirstlyDataResult>()
                 .ForMember(opt => opt.Description, des => des.MapFrom(src => src.Localize(src.DescriptionAr, src.DescriptionEn)));
        }
    }
}
