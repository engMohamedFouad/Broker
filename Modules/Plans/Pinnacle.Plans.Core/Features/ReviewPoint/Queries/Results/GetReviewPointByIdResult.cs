using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Results
{
    public class GetReviewPointByIdResult
    {
        public int Id { get; set; }
        public int? PointCategory { get; set; } //Noticeable Topics or ...
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public int? IndicatorId { get; set; }
        public int? IndicatorCode { get; set; }
        public int? Status { get; set; } //Closed,Open ,etc.
        public int? Type { get; set; } //essential or not
        public DateTime? StartDate { get; set; }
        public bool AbilityToComment { get; set; } = true;
        public string? Comment { get; set; }
        public List<PointsCommentDTO>? Comments { get; set; }
        public List<PointFilesDTO>? Files { get; set; }
        public List<AssignedUsers>? AssignedUsers { get; set; }

    }
    public class PointsCommentDTO
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public DateTime Created { get; set; }
    }


    public class AssignedUsers
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
    }
}
