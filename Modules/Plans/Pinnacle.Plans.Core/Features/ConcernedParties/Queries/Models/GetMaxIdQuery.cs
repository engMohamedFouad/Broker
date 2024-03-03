using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Models
{
    public class GetMaxIdQuery : IRequest<Response<int>>
    {
    }
}
