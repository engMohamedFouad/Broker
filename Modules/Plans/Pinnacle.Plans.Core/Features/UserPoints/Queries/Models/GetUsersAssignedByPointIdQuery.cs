using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.UserPoints.Queries.Results;

namespace Pinnacle.Plans.Core.Features.UserPoints.Queries.Models
{
    public class GetUsersAssignedByPointIdQuery : IRequest<Response<List<GetUsersAssignedByPointIdResult>>>
    {
        public int PointId { get; set; }
    }
}
