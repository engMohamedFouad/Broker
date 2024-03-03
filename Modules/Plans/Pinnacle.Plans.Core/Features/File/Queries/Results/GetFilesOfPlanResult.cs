namespace Pinnacle.Plans.Core.Features.File.Queries.Results
{
    public class GetFilesOfPlanResult
    {
        public int Id { get; set; }
        public string? Serial { get; set; }
        public string? Content { get; set; }
        public int? YPId { get; set; }
        public int? IndDetailsId { get; set; }
        public int? UserId { get; set; }
    }
}
