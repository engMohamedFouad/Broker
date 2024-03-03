namespace Broker.Core.Wrappers
{
    public class PaginatedRequest
    {
        public string? Search { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
