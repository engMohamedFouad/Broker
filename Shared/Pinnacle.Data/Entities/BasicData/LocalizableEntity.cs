using System.Globalization;

namespace Broker.Data.Entities.BasicData
{
    public class LocalizableEntity
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public string GetLocalized()
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;
            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return NameAr;
            return NameEn;
        }
    }
}
