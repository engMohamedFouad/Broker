using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData
{
    public class Setting
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [MinLength(10)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsArClient { get; set; }
        public string CondtionsEnClient { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string CondtionsArDelegt { get; set; }
        public string CondtionsEnDelegt { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsArClient { get; set; }
        public string AboutUsEnClient { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AboutUsArDelegt { get; set; }
        public string AboutUsEnDelegt { get; set; }

        public string SenderName { get; set; } = "test";
        public string UserNameSms { get; set; } = "test";
        public string PasswordSms { get; set; } = "test";
        public string ApplicationId { get; set; }
        public string SenderId { get; set; }
    }
}
