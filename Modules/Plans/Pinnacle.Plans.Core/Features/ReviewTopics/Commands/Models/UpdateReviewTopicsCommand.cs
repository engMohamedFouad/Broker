using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ReviewTopics.Commands.Models
{
    public class UpdateReviewTopicsCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? DescriptionAr { get; set; }
        public string? DescriptionEn { get; set; }
    }
}
