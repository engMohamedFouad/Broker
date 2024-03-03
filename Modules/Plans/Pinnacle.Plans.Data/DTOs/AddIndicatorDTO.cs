namespace Pinnacle.Plans.Data.DTOs
{
    public class AddIndicatorDTO
    {
        public int Code { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public int ImportanceForAll { get; set; } = 0;
        public int ImportanceForPerformance { get; set; } = 0;
        //yearly mounthly etc
        public int TradeBalancePeriod { get; set; } = 0;
        //part Of Users inside Indicator
        public int? PreparedById { get; set; }
        public DateTime? PreparedByTime { get; set; }
        public int? UpdatedById { get; set; }
        public DateTime? UpdatedByTime { get; set; }
        public int? ReviewedById { get; set; }
        public DateTime? ReviewedByTime { get; set; }
        public int? AdoptedById { get; set; }
        public DateTime? AdoptedByTime { get; set; }
    }
}

