using Domain.Enums;

namespace Domain.Entities
{
    public class MessageQueue
    {
        public Guid Id { get; set; }
        public Guid RezId { get; set; }
        public Rezervacija Rezervacija { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public DateTime Time { get; set; }
        public string MessageSubject { get; set; }
        public string Content { get; set; }
        public MessageStatus Status { get; set; } = MessageStatus.Pending;
    }
}
