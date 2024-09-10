using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string NameAr { get; set; } = "";
        public string NameEn { get; set; } = "";
        public bool IsActive { get; set; }
        public DateTime Date { get; set; }
    }
}
