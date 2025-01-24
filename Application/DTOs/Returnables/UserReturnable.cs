using Domain.Enums;

namespace Application.DTOs.Returnable
{
    public class UserReturnable
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserRoles Role { get; set; }

        public UserReturnable(Guid userId, string username, string email, UserRoles role)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Role = role;
        }

        public UserReturnable() { }
    }
}
