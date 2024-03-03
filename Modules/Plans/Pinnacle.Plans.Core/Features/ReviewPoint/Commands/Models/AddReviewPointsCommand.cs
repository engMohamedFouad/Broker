using MediatR;
using Microsoft.AspNetCore.Http;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Models
{
    public class AddReviewPointsCommand : IRequest<Response<string>>
    {
        public int? PointCategory { get; set; } = 0; //Noticeable Topics or ...
        public int? IndicatorId { get; set; }
        public int? Status { get; set; } = 0; //Closed,Open ,etc.
        public int? Type { get; set; } = 0; //essential or not
        public DateTime? StartDate { get; set; }
        public bool AbilityToComment { get; set; } = true;
        public string? Comment { get; set; } //At first only one comment
        public List<IFormFile>? Files { get; set; }
        public List<int>? AssignedUsers { get; set; }
    }

}
