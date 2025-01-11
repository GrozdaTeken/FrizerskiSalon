namespace Domain.Entities
{
    public class Blacklist
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string? Razlog { get; set; }
        public DateTime CreatedAt { get; set; }

        public Blacklist(string email, string telefon, string? razlog, DateTime createdAt)
        {
            Email = email;
            Telefon = telefon;
            Razlog = razlog;
            CreatedAt = createdAt;
        }

        public Blacklist()
        {
        }
    }
}
