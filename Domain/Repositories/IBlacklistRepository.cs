using Domain.Entities;

namespace Domain.Repositories
{
    public interface IBlacklistRepository
    {
        Task<Blacklist> AddToBlacklistAsync(Blacklist blacklist);
        Task<bool> RemoveFromBlacklistAsync(Guid id);
        Task<Blacklist> GetBlacklistedInfoAsync(Guid id);
        Task<IEnumerable<Blacklist>> GetAllBlacklistedAsync();
        Task UpdateBlacklistAsync(Blacklist blacklist);
    }
}
