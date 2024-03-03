namespace Pinnacle.Plans.Core.Features.ProceduresDetails.Queries.Results
{
    public class GetProcedureDetailsPaginationResult
    {
        public int ProcedureId { get; set; }
        public string? ProcedureName { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public bool IsUpdated { get; set; } = false;
        public string? Notes { get; set; }
        public List<string>? Files { get; set; }
    }
}
