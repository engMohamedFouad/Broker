using AutoMapper;

namespace Pinnacle.Plans.Core.Mappings.Indicators
{
    public partial class IndicatorProfile : Profile
    {
        public IndicatorProfile()
        {
            GetIndicatorPaginationMapping();
            GetIndicatorByIdMapping();
            AddIndicatorMapping();
            UpdateIndicatorMapping();
        }
    }
}
