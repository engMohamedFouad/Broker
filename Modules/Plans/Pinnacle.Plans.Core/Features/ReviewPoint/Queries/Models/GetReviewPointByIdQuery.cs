using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Results;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Models
{
    public class GetReviewPointByIdQuery : IRequest<Response<GetReviewPointByIdResult>>
    {
        public int Id { get; set; }
    }
}
