using Application.DTOs.Create;
using Application.DTOs.Returnable;
using Domain.Entities;

namespace Application.Extensions
{
    public static class FrizerExtensions
    {
        public static Frizer ConvertToEntity(this FrizerCreate dto)
        {
            return new Frizer
            {
                Ime = dto.Ime,
                Prezime = dto.Prezime,
                Telefon = dto.Telefon,
                Rezervacije = dto.Rezervacije
            };
        }

        public static FrizerReturnable ConvertToReturnable(this Frizer frizer)
        {
            return new FrizerReturnable
            {
                Id = frizer.Id,
                Ime = frizer.Ime,
                Prezime = frizer.Prezime,
                Telefon = frizer.Telefon,
                Rezervacije = frizer.Rezervacije
            };
        }
    }
}
