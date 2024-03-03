namespace Pinnacle.Plans.Core.Features.Procedures.Queries.Results
{
    public class GetProcedurePaginationResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsGeneral { get; set; } = false;
    }
}
