namespace Domain.Entities
{
    public class Frizer
    {
        public Guid Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }

        public ICollection<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();

        public Frizer(string ime, string prezime, string telefon, ICollection<Rezervacija> rezervacije)
        {
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            Rezervacije = rezervacije;
        }

        public Frizer()
        {
        }
    }
}
