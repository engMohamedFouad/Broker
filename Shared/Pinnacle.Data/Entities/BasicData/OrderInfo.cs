using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class OrderInfo
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int stutes { get; set; }
        public int Qty { get; set; }
        public string marketId { get; set; }
        public string? Unit { get; set; }
        public string Img { get; set; }
        public double DeliveryPrice { get; set; }
        public double Price { get; set; }
        public double totalPriceProduct { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual Orders Order { get; set; }
    }
}
