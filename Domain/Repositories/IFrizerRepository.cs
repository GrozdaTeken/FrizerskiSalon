using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFrizerRepository
    {
        Task<Frizer> AddFrizerAsync(Frizer frizer);
        Task<bool> DeleteFrizerAsync(Guid id);
        Task<Frizer?> GetFrizerByIdAsync(Guid id);
        Task<IEnumerable<Frizer>> GetAllFrizersAsync();
        Task UpdateFrizerAsync(Frizer frizer);
    }
}
