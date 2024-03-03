using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Features.SystemLogs.Queries.Models
{
    public class GetSystemLogsQuery : IRequest<PaginatedResult<GetSystemLogsResult>>
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
