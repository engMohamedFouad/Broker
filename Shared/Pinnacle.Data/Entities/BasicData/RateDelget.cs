using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class RateDelget
    {
        [Key]
        public int Id { get; set; }

        public string FkDeleget { get; set; }

        public string FkUser { get; set; }
        public DateTime Date { get; set; }
        public int Rate { get; set; } = 0;

        [ForeignKey(nameof(FkUser))]
        [InverseProperty(nameof(User.Client))]
        public virtual User ApplicationDbUser { get; set; }

        [ForeignKey(nameof(FkDeleget))]
        [InverseProperty(nameof(User.Delget))]
        public virtual User Deleget { get; set; }
    }
}
