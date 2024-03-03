using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Indicators.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Indicators.Queries.Models
{
    public class GetIndicatorPaginationQuary : IRequest<PaginatedResult<GetIndicatorPaginationResult>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
