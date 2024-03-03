using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class NotifyDelegt
    {
        [Key]
        public int Id { get; set; }
        [StringLength(450)]
        public string FKUser { get; set; }
        public string TextAr { get; set; }
        public string TextEn { get; set; }
        public DateTime Date { get; set; }
        public int? Type { get; set; }
        public bool? Show { get; set; }
        [ForeignKey(nameof(FKUser))]
        public virtual User ApplicationDbUser { get; set; }
    }
}
