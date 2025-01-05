using Application.DTOs.Create;
using Application.DTOs.Returnables;

namespace Application.Services.Interfaces
{
    public interface IBlacklistService
    {
        Task<BlacklistReturnable> AddBlacklistAsync(BlacklistCreate blacklist);
        Task<bool> DeleteBlacklistAsync(Guid id);
        Task<BlacklistReturnable?> GetBlacklistByIdAsync(Guid id);
        Task<IEnumerable<BlacklistReturnable>> GetBlacklistsAsync();
        Task<BlacklistReturnable> UpdateBlacklistAsync(Guid id, BlacklistCreate blacklist);
    }
}
