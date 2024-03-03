using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class ConnectUser
    {
        [Key]
        public int Id { get; set; }
        public string ContextId { get; set; }
        public DateTime date { get; set; } = DateTime.Now;

        public string FKUser { get; set; }

        [ForeignKey("FKUser")]
        public virtual User User { get; set; }
    }
}
