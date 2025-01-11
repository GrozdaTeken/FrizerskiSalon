namespace Application.DTOs.Create
{
    public class RezervacijaCreate
    {
        public Guid FriId { get; set; }
        public DateTime Termin { get; set; }
        public string? Ime { get; set; }
        public string? Mail { get; set; }
        public string? Telefon { get; set; }

        public RezervacijaCreate(Guid friId, DateTime termin, string? ime, string? mail, string? telefon)
        {
            FriId = friId;
            Termin = termin;
            Ime = ime;
            Mail = mail;
            Telefon = telefon;
        }

        public RezervacijaCreate()
        {
        }
    }
}