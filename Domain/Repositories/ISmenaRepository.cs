using Domain.Entities;

namespace Domain.Repositories
{
    public interface ISmenaRepository
    {
        Task AddAsync(Smena smena);
        Task<bool> DeleteAsync(Guid id);
        Task<Smena?> GetByIdAsync(Guid id);
        Task<IEnumerable<Smena>> GetAllAsync();
        Task UpdateAsync(Smena smena);
        Task<IEnumerable<Smena>> GetByFriIdAsync(Guid friId);
    }
}