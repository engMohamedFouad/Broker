namespace Pinnacle.Plans.Data.DTOs
{
    public class GetIndicatorByIdDTO
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int ImportanceForAll { get; set; } = 0;
        public int ImportanceForPerformance { get; set; } = 0;
        //yearly mounthly etc
        public int TradeBalancePeriod { get; set; } = 0;
        //part Of Users inside Indicator
        public int? PreparedById { get; set; }
        public string? PreparedBy { get; set; }
        public DateTime? PreparedByTime { get; set; }
        public int? UpdatedById { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedByTime { get; set; }
        public int? ReviewedById { get; set; }
        public string? ReviewedBy { get; set; }
        public DateTime? ReviewedByTime { get; set; }
        public int? AdoptedById { get; set; }
        public string? AdoptedBy { get; set; }
        public DateTime? AdoptedByTime { get; set; }
        public List<IndicatorDetailsDTO>? IndicatorDetails { get; set; }
    }
    public class IndicatorDetailsDTO
    {
        public int Id { get; set; }
        public int IndicatorId { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public string? Note { get; set; }
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public List<string>? Files { get; set; }
    }
}
