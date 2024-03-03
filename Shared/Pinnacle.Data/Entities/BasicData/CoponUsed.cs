using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData
{
    public class CoponUsed
    {
        [Key]
        public int ID { get; set; }
        public int FkCopon { get; set; }
        public int FkOrder { get; set; }
        public string FkUser { get; set; }
    }
}
