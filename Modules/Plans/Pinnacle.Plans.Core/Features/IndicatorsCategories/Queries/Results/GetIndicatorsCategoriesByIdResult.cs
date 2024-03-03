namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Results
{
    public class GetIndicatorsCategoriesByIdResult
    {
        public int Id { get; set; }
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }
        public List<IndicatorDTO>? IndicatorDTOs { get; set; }
    }
    public class IndicatorDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
