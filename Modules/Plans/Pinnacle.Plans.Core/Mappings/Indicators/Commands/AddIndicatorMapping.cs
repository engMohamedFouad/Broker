using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Indicators.Commands.Models;

namespace Pinnacle.Plans.Core.Mappings.Indicators
{
    public partial class IndicatorProfile
    {
        public void AddIndicatorMapping()
        {
            CreateMap<AddIndicatorCommand, Indicator>();
        }
    }
}
