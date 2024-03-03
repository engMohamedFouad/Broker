using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.IndicatorsCategories
{
    public partial class IndicatorsCategoriesProfile
    {
        public void GetIndicatorsCategoriesByIdMapping()
        {
            CreateMap<IndicatorsCategory, GetIndicatorsCategoriesByIdResult>();
            //  .ForMember(opt => opt.IndicatorDTOs, des => des.MapFrom(src => src.IndicatorsNavigation));
        }
    }
}
