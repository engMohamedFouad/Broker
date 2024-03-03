using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Mappings.Indicators
{
    public partial class IndicatorProfile
    {
        public void GetIndicatorByIdMapping()
        {
            //ToDo::Review Part of Procedures
            CreateMap<Indicator, GetIndicatorByIdDTO>();

        }
    }
}
