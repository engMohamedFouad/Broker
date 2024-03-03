using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Plans.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Plans.Queries.Models
{
    public class GetPlansPaginationQuery : IRequest<PaginatedResult<GetPlansPaginationResult>>
    {
        public string? Year { get; set; }
        public string? ConcernedParty { get; set; }
        public string? EmployeeName { get; set; }
        public bool Status { get; set; } = true;
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
