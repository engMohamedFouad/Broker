using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Governorates = new HashSet<Governorate>();
            Cities = new HashSet<City>();
        }

        [InverseProperty(nameof(Governorate.Country))]
        public virtual ICollection<Governorate> Governorates { get; set; }

        [InverseProperty(nameof(City.countries))]
        public virtual ICollection<City> Cities { get; set; }
    }
}
