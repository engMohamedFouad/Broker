namespace Broker.Data.Entities.BasicData
{
    public class Advertisment
    {
        public int Id { get; set; }
        public string TitleAr { get; set; }
        // enum يحدد ع حسب الاستخدام لو فى اكتر من اعلان فى المشروع
        public int Type { get; set; }
        public string TitleEn { get; set; }
        public string Img { get; set; }
        public bool IsActive { get; set; }
    }
}
