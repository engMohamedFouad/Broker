namespace Broker.Data.Entities.BasicData
{
    public class SmsMessage
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime Date { get; set; }
    }
}
