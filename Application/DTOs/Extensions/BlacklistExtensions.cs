using Domain.Entities;
using Application.DTOs.Create;
using Application.DTOs.Returnable;
using System.Runtime.CompilerServices;
using Application.DTOs.Returnables;


namespace Application.DTOs.Extensions
{
    public static class BlacklistExtensions
    {
        public static Blacklist ConvertToEntity(this BlacklistCreate dto)
        {
            return new Blacklist
            {
                Email = dto.Email,
                Telefon = dto.Telefon,
                Razlog = dto.Razlog,
                CreatedAt = dto.CreatedAt
            };
        }

        public static BlacklistReturnable ConvertToReturnable(this Blacklist blacklist)
        {
            return new BlacklistReturnable
            {
                Id = blacklist.Id,
                Email = blacklist.Email,
                Telefon = blacklist.Telefon,
                Razlog = blacklist.Razlog,
                CreatedAt = blacklist.CreatedAt
            };
        }
    }
}
