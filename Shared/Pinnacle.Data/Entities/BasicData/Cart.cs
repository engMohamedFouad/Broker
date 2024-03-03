using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class Cart
    {
        public double DeliveryPrice { get; set; }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public int Qty { get; set; }
        public string? Unit { get; set; }
        [ForeignKey(nameof(ProductId))]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
    }
}
