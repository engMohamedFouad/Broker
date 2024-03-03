using Pinnacle.Data.Entities.BasicData;
using Pinnacle.Plans.Core.Features.Indicators.Queries.Results;

namespace Pinnacle.Plans.Core.Mappings.Indicators
{
    public partial class IndicatorProfile
    {
        public void GetIndicatorPaginationMapping()
        {
            CreateMap<Indicator, GetIndicatorPaginationResult>()
                .ForMember(opt => opt.Name, des => des.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
