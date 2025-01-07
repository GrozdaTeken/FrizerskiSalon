using Application.DTOs.Create;
using Application.DTOs.Returnables;
using Domain.Entities;

namespace Application.DTOs.Extensions
{
    public static class SmenaExtensions
    {
        public static Smena ConvertToEntity(this SmenaCreate dto)
        {
            return new Smena
            {
                Id = Guid.NewGuid(),
                FriId = dto.FriId,
                Pocetak = dto.Pocetak,
                Kraj = dto.Kraj
            };
        }

        public static SmenaReturnable ConvertToReturnable(this Smena entity)
        {
            return new SmenaReturnable
            {
                Id = entity.Id,
                FriId = entity.FriId,
                Pocetak = entity.Pocetak,
                Kraj = entity.Kraj
            };
        }
    }
}