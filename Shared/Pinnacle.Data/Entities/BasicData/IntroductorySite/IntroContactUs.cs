using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData.IntroductorySite
{
    public class IntroContactUs
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل الأسم")]
        public string Name { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل رقم الهاتف")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "من فضلك ادخل الأيميل")]
        public string Email { get; set; }
        [Required(ErrorMessage = " من فضلك ادخل الرسالة")]
        public string Message { get; set; }
    }
}
