using Domain.Entities;

namespace Application.Services.Interfaces
{
    public interface IFrizerService
    {
        Task<Frizer> AddFrizerAsync(Frizer frizer);
        Task<bool> DeleteFrizerAsync(int id);
        Task<Frizer?> GetFrizerByIdAsync(int id);
        Task<IEnumerable<Frizer>> GetAllFrizersAsync();
        Task UpdateFrizerAsync(Frizer frizer);
    }
}
