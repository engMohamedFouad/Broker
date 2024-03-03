namespace Pinnacle.Plans.Core.Features.PointComments.Queries.Results
{
    public class GetPointsCommentsResult
    {
        public int Id { get; set; }
        public string? Content { get; set; }
        public int PointId { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int? ParentId { get; set; }
    }
}
