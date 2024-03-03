using Broker.Data.Entities.BasicData;
using Broker.Data.Entities.BasicData.IntroductorySite;
using Broker.Data.Entities.Identity;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Broker.Infrustructure.Context
{
    public class ApplicationDbContext : IdentityDbContext<User, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        private readonly IEncryptionProvider _encryptionProvider;
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<FavouriteMarket> FavouriteMarket { get; set; }
        public DbSet<OrderInfo> OrderInfos { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ProductImg> ProductImgs { get; set; }
        public DbSet<WholeSalerCategories> WholeSalerCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<WholeSalerOffer> WholeSalerOffers { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<LogExption> LogExption { get; set; }
        public DbSet<RateDelget> RateDelget { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<DeviceId> DeviceIds { get; set; }
        public DbSet<NotifyClient> NotifyClients { get; set; }
        public DbSet<NotifyDelegt> NotifyDelegts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Copon> Copon { get; set; }
        public DbSet<CoponUsed> CoponUsed { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Favourite> Favourites { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }
        public DbSet<ConnectUser> ConnectUser { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<HistoryNotify> HistoryNotify { get; set; }

        /// <summary>
        /// Section IntroductorySite
        /// </summary>
        public DbSet<IntroSetting> IntroSettings { get; set; }
        public DbSet<IntroContactUs> IntroContactUs { get; set; }
        public DbSet<CustomerOpinion> CustomerOpinions { get; set; }
        public DbSet<AppImg> AppImgs { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Governorate> Governorates { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Regoin> Regoins { get; set; }

    }
}
