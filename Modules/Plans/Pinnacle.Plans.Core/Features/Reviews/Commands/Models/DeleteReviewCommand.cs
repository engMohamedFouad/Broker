using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Reviews.Commands.Models
{
    public class DeleteReviewCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
