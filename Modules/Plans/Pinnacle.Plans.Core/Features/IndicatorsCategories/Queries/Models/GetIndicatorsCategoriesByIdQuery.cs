using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Results;

namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Models
{
    public class GetIndicatorsCategoriesByIdQuery : IRequest<Response<GetIndicatorsCategoriesByIdResult>>
    {
        public int Id { get; set; }
    }
}
