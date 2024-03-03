using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.File.Queries.Results;

namespace Pinnacle.Plans.Core.Features.File.Queries.Models
{
    public class GetFilesOfPlanQuery : PaginatedRequest, IRequest<PaginatedResult<GetFilesOfPlanResult>>
    {
        public int YPId { get; set; }
    }
}
