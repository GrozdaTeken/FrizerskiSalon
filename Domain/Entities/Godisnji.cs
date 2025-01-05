namespace Domain.Entities
{
    public class Godisnji
    {
        public Guid Id { get; set; }

        public Guid FriId { get; set; }
        public Frizer Frizer { get; set; }

        public DateTime GodisnjiOd { get; set; }
        public DateTime GodisnjiDo { get; set; }
    }
}
