namespace Pinnacle.Plans.Data.DTOs.IndicatorsDetails
{
    public class GetIndicatorDetailsByIndicatorIdResult
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
