using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRezervacijaRepository
    {
        Task AddAsync(Rezervacija rezervacija);
        Task<bool> DeleteAsync(Guid id);
        Task<Rezervacija?> GetByIdAsync(Guid id);
        Task<IEnumerable<Rezervacija>> GetAllAsync();
        Task UpdateAsync(Rezervacija rezervacija);
        Task<IEnumerable<Rezervacija>> GetByFriIdAsync(Guid friId);
    }
}