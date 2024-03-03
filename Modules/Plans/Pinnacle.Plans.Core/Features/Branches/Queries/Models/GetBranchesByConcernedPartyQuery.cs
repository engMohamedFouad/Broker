using MediatR;
using Pinnacle.Core.Wrappers;
using Pinnacle.Plans.Core.Features.Branches.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Branches.Queries.Models
{
    public class GetBranchesByConcernedPartyQuery : PaginatedRequest, IRequest<PaginatedResult<GetBranchesByConcernedPartyResult>>
    {
        public int ConcernedPartyId { get; set; }
    }
}
