using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.IndicatorsCategories
{
    public partial class IndicatorsCategoriesProfile
    {
        public void GetIndicatorsCategoriesMapping()
        {
            CreateMap<IndicatorsCategory, GetIndicatorsCategoriesPaginationResult>()
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
            // .ForMember(opt => opt.IndicatorDTOs, des => des.MapFrom(src => src.IndicatorsNavigation));

            CreateMap<Indicator, IndicatorDTO>()
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
