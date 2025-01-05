namespace Application.DTOs.Returnables
{
    public class BlacklistReturnable
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Razlog { get; set; }
        public DateTime CreatedAt { get; set; }

        public BlacklistReturnable(Guid id, string email, string telefon, string razlog, DateTime createdAt)
        {
            Id = id;
            Email = email;
            Telefon = telefon;
            Razlog = razlog;
            CreatedAt = createdAt;
        }

        public BlacklistReturnable()
        {
        }
    }
}
