using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Results;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Models
{
    public class GetConcernedPartiesByIdQuery : IRequest<Response<GetConcernedPartiesByIdResult>>
    {
        public int Id { get; set; }
    }
}
