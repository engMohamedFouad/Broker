namespace Broker.Data.Entities.BasicData
{
    public class Favourite
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
    }
}
