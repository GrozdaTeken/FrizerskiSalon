using Domain.Entities;

namespace Domain.Repositories
{
    public interface IFrizerRepository
    {
        Task<Frizer> AddFrizerAsync(Frizer frizer);
        Task<bool> DeleteFrizerAsync(int id);
        Task<Frizer?> GetFrizerByIdAsync(int id);
        Task<IEnumerable<Frizer>> GetAllFrizersAsync();
        Task UpdateFrizerAsync(Frizer frizer);
    }
}
