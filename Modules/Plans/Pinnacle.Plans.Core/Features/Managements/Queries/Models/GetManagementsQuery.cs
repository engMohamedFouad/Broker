using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Managements.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Managements.Queries.Models
{
    public class GetManagementsQuery : IRequest<PaginatedResult<GetManagementsResult>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
