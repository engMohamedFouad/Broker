using Broker.Data.Entities.Identity;

namespace Broker.Data.Entities.BasicData
{
    public class Payment : BaseEntity
    {
        public string UserID { get; set; }
        public virtual User User { get; set; }
        public string InvoiceID { get; set; }
        public virtual Orders Orders { get; set; }
        public int OrdersID { get; set; }
        public string PaymentType { get; set; }
        public string TrackID { get; set; }
        public string URL { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; } = "SAR";
        public string Method { get; set; } = "CARD";
        public string Data { get; set; }
        public DateTime PaidAt { get; set; }
        public bool IsPaid { get; set; } = false;

    }

}
