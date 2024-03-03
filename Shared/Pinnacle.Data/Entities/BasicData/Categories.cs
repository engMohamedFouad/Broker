using Broker.Data.Entities.Identity;

namespace Broker.Data.Entities.BasicData
{
    public class Categories : BaseEntity
    {
        public string Image { get; set; }
        public virtual ICollection<User> WholeSalers { get; set; }
    }
}
