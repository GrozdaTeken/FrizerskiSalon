using Domain.Entities;

namespace Domain.Repositories
{
    public interface IGodisnjiRepository
    {
        Task AddAsync(Godisnji godisnji);
        Task<bool> DeleteAsync(Guid id);
        Task<Godisnji?> GetByIdAsync(Guid id);
        Task<IEnumerable<Godisnji>> GetAllAsync();
        Task UpdateAsync(Godisnji godisnji);
        Task<IEnumerable<Godisnji>> GetByFriIdAsync(Guid friId);
    }
}