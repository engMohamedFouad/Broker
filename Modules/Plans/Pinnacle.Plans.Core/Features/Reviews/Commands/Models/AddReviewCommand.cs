using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Reviews.Commands.Models
{
    public class AddReviewCommand : IRequest<Response<string>>
    {
        public string? TypeAr { get; set; }
        public string? TypeEn { get; set; }
    }
}
