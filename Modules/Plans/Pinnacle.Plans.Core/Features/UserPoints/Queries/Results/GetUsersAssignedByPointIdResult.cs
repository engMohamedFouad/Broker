namespace Pinnacle.Plans.Core.Features.UserPoints.Queries.Results
{
    public class GetUsersAssignedByPointIdResult
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public int PointId { get; set; }
    }
}
