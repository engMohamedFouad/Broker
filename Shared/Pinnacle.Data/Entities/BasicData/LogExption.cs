using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData
{
    public class LogExption
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ServiceName { get; set; }
        public string Exption { get; set; }
        public DateTime Date { get; set; }
    }
}
