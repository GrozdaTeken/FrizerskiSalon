namespace Domain.Entities
{
    public class Godisnji
    {
        public int Id { get; set; }

        public int FriId { get; set; }
        public Frizer Frizer { get; set; }

        public DateTime GodisnjiOd { get; set; }
        public DateTime GodisnjiDo { get; set; }
    }
}
