using MediatR;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.Reviews.Commands.Models
{
    public class UpdateReviewCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? TypeAr { get; set; }
        public string? TypeEn { get; set; }
    }
}
