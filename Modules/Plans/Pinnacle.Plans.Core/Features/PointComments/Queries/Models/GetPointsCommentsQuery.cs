using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.PointComments.Queries.Results;

namespace Pinnacle.Plans.Core.Features.PointComments.Queries.Models
{
    public class GetPointsCommentsQuery : IRequest<Response<List<GetPointsCommentsResult>>>
    {
        public int PointId { get; set; }
    }
}
