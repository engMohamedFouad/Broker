using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class Orders
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Location { get; set; }
        public string Lat { get; set; }
        public string Lng { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime Date { get; set; }
        public double TotalDeliveryPrice { get; set; }
        public double Total { get; set; }
        public double LastTotal { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public virtual ICollection<OrderInfo> OrderInfos { get; set; } = new HashSet<OrderInfo>();

        [InverseProperty(nameof(Messages.Order))]
        public virtual ICollection<Messages> MessagesNavigations { get; set; } = new HashSet<Messages>();


    }
}
