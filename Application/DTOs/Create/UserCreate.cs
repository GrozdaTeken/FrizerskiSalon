using Domain.Enums;

namespace Application.DTOs.Create
{
    public class UserCreate
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public UserRoles Role { get; set; }
        public string Password { get; set; }
        public UserCreate(string username, string email, UserRoles role, string password)
        {
            Username = username;
            Email = email;
            Role = role;
            Password = password;
        }

        public UserCreate()
        { }
    }
}
