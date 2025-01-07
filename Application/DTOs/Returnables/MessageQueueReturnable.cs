using Domain.Enums;

namespace Application.DTOs.Returnables
{
    public class MessageQueueReturnable
    {
        public Guid Id { get; set; }
        public Guid RezId { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public DateTime Time { get; set; }
        public string MessageSubject { get; set; }
        public string Content { get; set; }
        public MessageStatus Status { get; set; }

        public MessageQueueReturnable(Guid id, Guid rezId, string receiver, string sender, DateTime time, string messageSubject, string content, MessageStatus status)
        {
            Id = id;
            RezId = rezId;
            Receiver = receiver;
            Sender = sender;
            Time = time;
            MessageSubject = messageSubject;
            Content = content;
            Status = status;
        }

        public MessageQueueReturnable() { }
    }
}