using Broker.Data.Entities.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Broker.Data.Entities.BasicData
{
    public class Messages
    {
        [Key]
        public int Id { get; set; }
        public int FKOrder { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Text { get; set; }
        public DateTime DateSend { get; set; }
        public bool SenderSeen { get; set; }
        public bool ReceiverSeen { get; set; }
        public bool IsDeletedSender { get; set; }
        public bool IsDeletedReceiver { get; set; }
        public int Duration { get; set; }


        public int TypeMessage { get; set; }

        [ForeignKey(nameof(SenderId))]
        [InverseProperty(nameof(User.Sender))]
        public virtual User Sender { get; set; }
        [ForeignKey(nameof(ReceiverId))]
        [InverseProperty(nameof(User.Receiver))]
        public virtual User Receiver { get; set; }
        [ForeignKey(nameof(FKOrder))]
        [InverseProperty(nameof(Orders.MessagesNavigations))]
        public virtual Orders Order { get; set; }

    }
}
