using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class WholeSalerCategories : BaseEntity
    {
        public WholeSalerCategories()
        {
            Products = new HashSet<Product>();
        }
        public string Image { get; set; }
        public string WholeSalerId { get; set; }
        [ForeignKey(nameof(WholeSalerId))]
        public virtual User WholeSaler { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
