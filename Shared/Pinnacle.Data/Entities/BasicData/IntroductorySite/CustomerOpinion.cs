using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData.IntroductorySite
{
    public class CustomerOpinion
    {
        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
    }
}
