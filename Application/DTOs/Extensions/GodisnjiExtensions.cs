using Application.DTOs.Create;
using Application.DTOs.Returnables;
using Domain.Entities;

namespace Application.DTOs.Extensions
{
    public static class GodisnjiExtensions
    {
        public static Godisnji ConvertToEntity(this GodisnjiCreate dto)
        {
            return new Godisnji
            {
                Id = Guid.NewGuid(),
                FriId = dto.FriId,
                GodisnjiOd = dto.GodisnjiOd,
                GodisnjiDo = dto.GodisnjiDo
            };
        }

        public static GodisnjiReturnable ConvertToReturnable(this Godisnji godisnji)
        {
            return new GodisnjiReturnable
            {
                Id = godisnji.Id,
                FriId = godisnji.FriId,
                GodisnjiOd = godisnji.GodisnjiOd,
                GodisnjiDo = godisnji.GodisnjiDo
            };
        }
    }
}