using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData
{
    public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string UserName { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        public string Msg { get; set; }
        public DateTime Date { get; set; }
    }
}
