namespace Domain.Entities
{
    public class Smena
    {
        public Guid Id { get; set; }
        public Guid FriId { get; set; }
        public Frizer Frizer { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
    }
}
