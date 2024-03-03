using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductImgs = new HashSet<ProductImg>();
        }
        public string DescriptionAr { get; set; }
        public string DescriptionEn { get; set; }

        public double DeliveryPrice { get; set; }
        public double Price { get; set; }
        public double PriceAfterDic { get; set; }
        public int WholeSalerCategoriesId { get; set; }
        public string UserId { get; set; }
        public string Unit { get; set; }
        public bool ISPermited { get; set; }
        public string ChangeLangDescription(string lang = "ar")
        {

            return AAITHelper.HelperMsg.creatMessage(lang, DescriptionAr, DescriptionEn);
        }
        [ForeignKey(nameof(WholeSalerCategoriesId))]
        public virtual WholeSalerCategories WholeSalerCategory { get; set; }
        public virtual ICollection<ProductImg> ProductImgs { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User users { get; set; }


    }
}
