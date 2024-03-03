using MediatR;
using Pinnacle.Core.Bases;
using Pinnacle.Plans.Core.Features.Reviews.Queries.Results;

namespace Pinnacle.Plans.Core.Features.Reviews.Queries.Models
{
    public class GetReviewByIdQuery : IRequest<Response<GetReviewByIdResult>>
    {
        public int Id { get; set; }
    }
}
