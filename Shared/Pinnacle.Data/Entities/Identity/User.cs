using Broker.Data.Entities.BasicData;
using EntityFrameworkCore.EncryptColumn.Attribute;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public User()
        {
            UserRefreshTokens = new HashSet<UserRefreshToken>();
            ContactUs = new HashSet<ContactUs>();
            NotifyClient = new HashSet<NotifyClient>();
            NotifyDelegt = new HashSet<NotifyDelegt>();
            DeviceIdNavigations = new HashSet<DeviceId>();
            Sender = new HashSet<Messages>();
            Receiver = new HashSet<Messages>();
            ConnectUser = new HashSet<ConnectUser>();
            HistoryNotify = new HashSet<HistoryNotify>();
            OrdersNavigations = new HashSet<Orders>();
            WholeSalerOffers = new HashSet<WholeSalerOffer>();
            WholeSalerCategories = new HashSet<WholeSalerCategories>();
            Product = new HashSet<Product>();
        }
        #region WholeSaler
        public int? CategoryId { get; set; }
        public string? TimeFrom { get; set; }
        public string? TimeTo { get; set; }
        public double DeliveryPrice { get; set; } = 0;
        #endregion
        public string FullName { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Location { get; set; } = "";
        public string? Lat { get; set; } = "";
        public string? Lng { get; set; } = "";
        public bool ActiveCode { get; set; } = false;
        public bool IsActive { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
        // public int Code { get; set; } = 1234;
        public string? ShowPassword { get; set; }
        public string? Lang { get; set; } = "ar";  //اللغه هتكون عند اليوزر وتكون عربى فى الاول - وتتغير بسيرفس
        public DateTime PublishDate { get; set; } = DateTime.Now;
        ////تم اضافته لتعامل مع السيرفس اما 
        ////UuserName  ده هنساويه بال email
        //public string user_Name { get; set; } //= first_name + " " + last_name;
        public int TypeUser { get; set; } //Client = 1  //deleget = 2 //org_delget = 3//Admin = 4
        public bool CloseNotify { get; set; } = false; //تفعيل الاشعار
        public string? ImgProfile { get; set; } = "";
        // for billing
        //[Required(ErrorMessage = "من فضلك ادخل اسم الشارع")]
        public string? Street { get; set; }
        //[Required(ErrorMessage = "من فضلك ادخل اسم المدينة")]
        public string? City { get; set; }
        //[Required(ErrorMessage = "من فضلك ادخل اسم المنطقة")]
        public string? State { get; set; }
        //[RegularExpression("[A-Z]{2}", ErrorMessage = "ادخل كود الدولة بشكل صحيح مثال : SA")]
        //  public string? Country { get; set; }
        //[Required(ErrorMessage = "من فضلك ادخل الرمز البريدي")]
        public string? PostCode { get; set; }
        //Relation
        [ForeignKey(nameof(CategoryId))]
        public virtual Categories? Category { get; set; }
        public virtual ICollection<WholeSalerOffer> WholeSalerOffers { get; set; }
        public virtual ICollection<WholeSalerCategories> WholeSalerCategories { get; set; }
        //ContactUs >> user  m>> o
        public virtual ICollection<ContactUs> ContactUs { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        //DevieId >> user  m>> o
        [InverseProperty(nameof(DeviceId.UserNavigation))]
        public virtual ICollection<DeviceId> DeviceIdNavigations { get; set; }
        //notifyclient >> user  m>> o
        public virtual ICollection<NotifyClient> NotifyClient { get; set; }
        //notifyDelegt >> user m>> o
        public virtual ICollection<NotifyDelegt> NotifyDelegt { get; set; }
        [InverseProperty(nameof(RateDelget.Deleget))]
        public virtual ICollection<RateDelget> Delget { get; set; }
        [InverseProperty(nameof(RateDelget.ApplicationDbUser))]
        public virtual ICollection<RateDelget> Client { get; set; }
        public virtual ICollection<Messages> Sender { get; set; }
        public virtual ICollection<Messages> Receiver { get; set; }
        [InverseProperty(nameof(Orders.User))]
        public virtual ICollection<Orders> OrdersNavigations { get; set; }
        public virtual ICollection<ConnectUser> ConnectUser { get; set; }
        public virtual ICollection<HistoryNotify> HistoryNotify { get; set; }
        [EncryptColumn]
        public string? Code { get; set; }
        [InverseProperty(nameof(UserRefreshToken.user))]
        public virtual ICollection<UserRefreshToken> UserRefreshTokens { get; set; }

    }
}
