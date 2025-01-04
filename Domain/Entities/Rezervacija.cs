namespace Domain.Entities
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public int FriId { get; set; }
        public Frizer Frizer { get; set; }
        public DateTime Termin { get; set; }
        public string Ime { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }
        public ICollection<MessageQueue> MessageQueues { get; set; }
    }
}
