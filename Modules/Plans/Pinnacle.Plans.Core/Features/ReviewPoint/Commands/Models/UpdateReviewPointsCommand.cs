using MediatR;
using Microsoft.AspNetCore.Http;
using Pinnacle.Core.Bases;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Commands.Models
{
    public class UpdateReviewPointsCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public int? PointCategory { get; set; } //Noticeable Topics or ...
        public int? IndicatorId { get; set; }
        public int? Status { get; set; } //Closed,Open ,etc.
        public int? Type { get; set; } //essential or not
        public DateTime? StartDate { get; set; }
        public bool AbilityToComment { get; set; } = true;
        public List<IFormFile>? Files { get; set; }
        public List<int>? AssignedUsers { get; set; }
        public string? Comment { get; set; }
    }
}

