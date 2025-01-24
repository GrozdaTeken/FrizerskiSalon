using Domain.Entities;

namespace Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByIdAsync(Guid? id);
        Task<IEnumerable<User>> GetAllUsersAsync(Guid? staId);
        Task<User> AddUserAsync(User user);
        Task UpdateUserAsync();
        Task<bool> DeleteUserAsync(Guid guid);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);

        Task<bool> EmailExistAsync(string email);
        Task<User> GetUserByEmailAsync(string email);
    }
}
