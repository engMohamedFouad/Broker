using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Models
{
    public class AddReviewTopicsCommand : IRequest<Response<string>>
    {
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
    }
}
