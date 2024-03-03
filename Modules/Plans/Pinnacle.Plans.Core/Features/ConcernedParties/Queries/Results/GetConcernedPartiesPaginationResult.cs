namespace Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Results
{
    public class GetConcernedPartiesPaginationResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? PartyType { get; set; }
        public string? ManagerName { get; set; }
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public string? TradingNumber { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string? TaxNumber { get; set; }
    }
}
