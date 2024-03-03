using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Results;

namespace Pinnacle.Plans.Core.Features.FirstlyInformation.Queries.Models
{
    public class GetFirstlyDataQuery : IRequest<PaginatedResult<GetFirstlyDataResult>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
