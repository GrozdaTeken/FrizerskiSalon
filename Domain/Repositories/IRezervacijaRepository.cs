using Domain.Entities;

namespace Domain.Repositories
{
    public interface IRezervacijaRepository
    {
        Task AddAsync(Rezervacija rezervacija);
        Task<bool> DeleteAsync(Guid id);
        Task<Rezervacija?> GetByIdAsync(Guid id);
        Task<IEnumerable<Rezervacija>> GetAllAsync();
        Task<bool> UpdateAsync(Rezervacija rezervacija);
        Task<IEnumerable<Rezervacija>> GetByFriIdAsync(Guid friId);
        Task<bool> DeleteAllAsync();
        Task<IEnumerable<Rezervacija>> GetReservationsByDateAsync(DateTime date);
        Task<bool> CancelReservationAsync(Guid rezId);
        Task<IEnumerable<Rezervacija>> GetReservationsByFriIdAndDate(Guid friId, DateTime date);
    }
}