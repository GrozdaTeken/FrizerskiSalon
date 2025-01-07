using Application.DTOs.Create;
using Application.DTOs.Returnables;
using Domain.Entities;

namespace Application.DTOs.Extensions
{
    public static class RezervacijaExtensions
    {
        public static Rezervacija ConvertToEntity(this RezervacijaCreate dto)
        {
            return new Rezervacija
            {
                Id = Guid.NewGuid(),
                FriId = dto.FriId,
                Termin = dto.Termin,
                Ime = dto.Ime,
                Mail = dto.Mail,
                Telefon = dto.Telefon
            };
        }

        public static RezervacijaReturnable ConvertToReturnable(this Rezervacija rezervacija)
        {
            return new RezervacijaReturnable
            {
                Id = rezervacija.Id,
                FriId = rezervacija.FriId,
                Termin = rezervacija.Termin,
                Ime = rezervacija.Ime,
                Mail = rezervacija.Mail,
                Telefon = rezervacija.Telefon
            };
        }
    }
}