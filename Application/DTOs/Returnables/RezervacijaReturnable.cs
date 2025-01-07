namespace Application.DTOs.Returnables
{
    public class RezervacijaReturnable
    {
        public Guid Id { get; set; }
        public Guid FriId { get; set; }
        public DateTime Termin { get; set; }
        public string Ime { get; set; }
        public string Mail { get; set; }
        public string Telefon { get; set; }

        public RezervacijaReturnable(Guid id, Guid friId, DateTime termin, string ime, string mail, string telefon)
        {
            Id = id;
            FriId = friId;
            Termin = termin;
            Ime = ime;
            Mail = mail;
            Telefon = telefon;
        }

        public RezervacijaReturnable()
        {
        }
    }
}