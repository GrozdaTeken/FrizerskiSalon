namespace Application.DTOs.Update
{
    public class RezervacijaUpdate
    {
        public string? Ime { get; set; }
        public string? Mail { get; set; }
        public string? Telefon { get; set; }

        public RezervacijaUpdate(string? ime, string? mail, string? telefon)
        {
            Ime = ime;
            Mail = mail;
            Telefon = telefon;
        }

        public RezervacijaUpdate()
        {
        }
    }
}
