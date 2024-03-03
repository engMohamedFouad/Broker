using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.Identity
{
    public class UserPermissions
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Type { get; set; }
        [StringLength(100)]
        public string Value { get; set; }
    }
}
