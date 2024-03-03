using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Models
{
    public class DeleteReviewTopicsCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
    }
}
