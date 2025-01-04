namespace Domain.Entities
{
    public class MessageQueue
    {
        public int Id { get; set; }
        public int RezId { get; set; }
        public Rezervacija Rezervacija { get; set; }
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public DateTime Time { get; set; }
        public string MessageSubject { get; set; }
        public string Content { get; set; }
        public string Status { get; set; } = "Pending";
    }
}
