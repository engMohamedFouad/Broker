namespace Pinnacle.Plans.Core.Features.ReviewPoint.Queries.Results
{
    public class GetReviewPointsResult
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

    }
}
