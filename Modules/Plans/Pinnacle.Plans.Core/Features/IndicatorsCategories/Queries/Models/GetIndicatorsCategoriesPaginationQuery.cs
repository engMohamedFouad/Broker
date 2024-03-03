using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Results;

namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Models
{
    public class GetIndicatorsCategoriesPaginationQuery : PaginatedRequest, IRequest<PaginatedResult<GetIndicatorsCategoriesPaginationResult>>
    {

    }
}
