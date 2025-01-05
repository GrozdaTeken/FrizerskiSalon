using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRezervacijaRepository
    {
        Task<IEnumerable<Rezervacija>> GetAllAsync();
        Task<Rezervacija> GetByIdAsync(Guid rezId);
        Task AddAsync(Rezervacija rezervacija);
        Task UpdateAsync(Rezervacija rezervacija);
        Task DeleteAsync(Guid rezId);
    }
}
