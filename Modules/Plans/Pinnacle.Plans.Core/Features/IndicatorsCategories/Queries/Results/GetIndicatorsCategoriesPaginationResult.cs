namespace Pinnacle.Plans.Core.Features.IndicatorsCategories.Queries.Results
{
    public class GetIndicatorsCategoriesPaginationResult
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<IndicatorDTO>? IndicatorDTOs { get; set; }
    }
}
