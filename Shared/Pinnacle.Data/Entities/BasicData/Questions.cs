using System.ComponentModel.DataAnnotations;

namespace Broker.Data.Entities.BasicData
{
    public class Questions
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Question { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string Answer { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string QuestionEn { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string AnswerEn { get; set; }
        public bool IsActive { get; set; }
    }
}
