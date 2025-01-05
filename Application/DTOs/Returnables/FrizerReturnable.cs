using Domain.Entities;

namespace Application.DTOs.Returnable
{
    public class FrizerReturnable
    {
        public Guid Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Telefon { get; set; }
        public ICollection<Rezervacija> Rezervacije { get; set; } = new List<Rezervacija>();

        public FrizerReturnable(Guid id, string ime, string prezime, string telefon, ICollection<Rezervacija> rezervacije)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            Rezervacije = rezervacije;
        }

        public FrizerReturnable() { }
    }
}
