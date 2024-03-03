using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData.IntroductorySite
{
    public class Advantage
    {
        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
        public string TitleAr { get; set; }
        public string TitleEn { get; set; }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }
        public bool IsActive { get; set; }
    }
}
