using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Models
{
    public class DeleteReviewPointsCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
