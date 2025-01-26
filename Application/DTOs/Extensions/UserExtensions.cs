using Application.DTOs.Create;
using Application.DTOs.Returnable;
using Domain.Entities;

namespace Application.Extensions
{
    public static class UserExtensions
    {
        public static User ConvertToEntity(this UserCreate dto, string password)
        {
            return new User
            {
                Username = dto.Username,
                Email = dto.Email,
                Role = dto.Role,
                Password = password
            };
        }

        public static UserReturnable ConvertToReturnable(this User user)
        {
            return new UserReturnable
            {
                UserId = user.UserId,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
