using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class DeviceId
    {
        [Key]
        public int Id { get; set; }
        public string? FkUser { get; set; }
        public string? DeviceId_ { get; set; }
        public string? ProjectName { get; set; }
        public string? DeviceType { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey(nameof(FkUser))]
        [InverseProperty(nameof(User.DeviceIdNavigations))]
        public virtual User UserNavigation { get; set; }
    }
}
