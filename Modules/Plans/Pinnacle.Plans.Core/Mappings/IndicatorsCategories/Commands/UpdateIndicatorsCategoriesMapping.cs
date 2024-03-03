using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.IndicatorsCategories
{
    public partial class IndicatorsCategoriesProfile
    {
        public void UpdateIndicatorsCategoriesMapping()
        {
            CreateMap<UpdateIndicatorsCategoriesCommand, IndicatorsCategory>();
        }
    }
}
