using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class WholeSalerOffer
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string WholeSalerId { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey(nameof(WholeSalerId))]
        public virtual User WholeSaler { get; set; }
    }
}
