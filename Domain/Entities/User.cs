using Domain.Enums;

namespace Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserRoles Role { get; set; }
        public string Password{ get; set; }

        public User(Guid userId, string username, string email, UserRoles role, string password)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Role = role;
            Password = password;
        }

        public User() { }
    }
}
