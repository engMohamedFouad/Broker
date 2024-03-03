using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class Governorate : BaseEntity
    {
        public Governorate()
        {
            Cities = new HashSet<City>();
        }
        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        [InverseProperty(nameof(Country.Governorates))]
        public virtual Country Country { get; set; }

        [InverseProperty(nameof(City.Governorate))]
        public virtual ICollection<City> Cities { get; set; }
    }
}
