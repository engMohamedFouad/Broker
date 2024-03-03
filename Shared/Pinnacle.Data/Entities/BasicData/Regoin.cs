using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class Regoin : BaseEntity
    {

        public int CityId { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty(nameof(City.Regoins))]
        public virtual City City { get; set; }
    }
}
