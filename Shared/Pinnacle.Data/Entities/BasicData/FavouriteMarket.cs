namespace Broker.Data.Entities.BasicData
{
    public class FavouriteMarket
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string MarketId { get; set; }
        public DateTime Date { get; set; }
    }
}
