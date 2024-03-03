using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class City : BaseEntity
    {
        public int GovernorateId { get; set; }
        public int CountryId { get; set; }

        [ForeignKey(nameof(GovernorateId))]
        [InverseProperty(nameof(Governorate.Cities))]
        public virtual Governorate Governorate { get; set; }
        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Country.Cities))]
        public virtual Country countries { get; set; }

        [InverseProperty(nameof(Regoin.City))]
        public virtual ICollection<Regoin> Regoins { get; set; }

    }
}
