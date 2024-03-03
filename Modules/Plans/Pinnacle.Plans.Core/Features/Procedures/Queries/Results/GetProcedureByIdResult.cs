namespace Pinnacle.Plans.Core.Features.Procedures.Queries.Results
{
    public class GetProcedureByIdResult
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public bool IsGeneral { get; set; } = false;
    }
}
