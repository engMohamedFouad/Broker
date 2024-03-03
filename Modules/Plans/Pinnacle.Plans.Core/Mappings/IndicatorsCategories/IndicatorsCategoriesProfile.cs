using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.IndicatorsCategories
{
    public partial class IndicatorsCategoriesProfile : Profile
    {
        public IndicatorsCategoriesProfile()
        {
            GetIndicatorsCategoriesMapping();
            GetIndicatorsCategoriesByIdMapping();
            AddIndicatorsCategoriesMapping();
            UpdateIndicatorsCategoriesMapping();
        }
    }
}
