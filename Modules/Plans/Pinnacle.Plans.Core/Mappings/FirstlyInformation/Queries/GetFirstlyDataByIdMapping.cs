using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.FirstlyInformation
{
    public partial class FirstlyDataProfile
    {
        public void GetFirstlyDataByIdMapping()
        {
            CreateMap<FirstlyData, GetFirstlyDataByIdResult>()
                 .ForMember(opt => opt.ReviewType, des => des.MapFrom(src => src.Localize(src.ReviewNavigation.TypeAr, src.ReviewNavigation.TypeEn)));
        }
    }
}
