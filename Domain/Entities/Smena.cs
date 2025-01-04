namespace Domain.Entities
{
    public class Smena
    {
        public int Id { get; set; }
        public int FriId { get; set; }
        public Frizer Frizer { get; set; }
        public DateTime Pocetak { get; set; }
        public DateTime Kraj { get; set; }
    }
}
