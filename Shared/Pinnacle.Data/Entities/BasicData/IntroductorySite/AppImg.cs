using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData.IntroductorySite
{
    public class AppImg
    {
        [Key]
        public int Id { get; set; }
        public string Img { get; set; }
        public bool IsActive { get; set; }

    }
}
