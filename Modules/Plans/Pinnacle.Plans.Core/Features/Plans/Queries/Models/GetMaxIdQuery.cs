using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Plans.Queries.Models
{
    public class GetMaxIdQuery : IRequest<Response<int>>
    {
    }
}
