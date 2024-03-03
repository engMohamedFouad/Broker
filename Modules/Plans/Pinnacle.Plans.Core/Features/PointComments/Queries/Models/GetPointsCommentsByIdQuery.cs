using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.PointComments.Queries.Results;

namespace Pinnacle.Plans.Core.Features.PointComments.Queries.Models
{
    public class GetPointsCommentsByIdQuery : IRequest<Response<GetPointsCommentsByIdResult>>
    {
        public int Id { get; set; }
    }
}
