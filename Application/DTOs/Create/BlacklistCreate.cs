namespace Application.DTOs.Create
{
    public class BlacklistCreate
    {
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Razlog { get; set; }
        public DateTime CreatedAt { get; set; }

        public BlacklistCreate(string email, string telefon, string razlog, DateTime createdAt)
        {
            Email = email;
            Telefon = telefon;
            Razlog = razlog;
            CreatedAt = createdAt;
        }
    }
}
