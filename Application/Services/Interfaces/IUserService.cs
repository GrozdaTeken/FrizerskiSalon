using Application.DTOs.Create;
using Application.DTOs.Returnable;

namespace Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserReturnable> GetUserByIdAsync(Guid id);
        Task<UserReturnable> AddUserAsync(UserCreate UserCreate);
        Task<UserReturnable> UpdateUserAsync(UserCreate UserCreate);
        Task<bool> DeleteUserAsync(Guid memId);
        Task<IEnumerable<UserReturnable>> GetAllUsersAsync(Guid? staId);
        Task<UserReturnable> GetUserByEmailAndPasswordAsync(string email, string password);
        Task<UserReturnable> GetUserByUsernameAndPasswordAsync(string  username, string password);
        Task<bool> EmailExistAsync(string email);
        Task<UserReturnable> GetUserByEmailAsync(string email);
    }
}
