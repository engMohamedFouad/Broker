using Pinnacle.Plans.Data.DTOs;

namespace Pinnacle.Plans.Core.Features.ConcernedParties.Queries.Results
{
    public class GetConcernedPartiesByIdResult
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int? PartyType { get; set; }
        public string? ManagerName { get; set; }
        public string? Email { get; set; }
        public string? WebSite { get; set; }
        public string? TradingNumber { get; set; }
        public DateTime? RegisterDate { get; set; }
        public string? TaxNumber { get; set; }
        public List<string>? PhoneNumbers { get; set; }
        public List<BranchesDTO>? BranchNames { get; set; }
    }

}
