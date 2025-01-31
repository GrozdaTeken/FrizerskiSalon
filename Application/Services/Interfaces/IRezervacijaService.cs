using Application.DTOs.Create;
using Application.DTOs.Returnables;
using Application.DTOs.Update;

namespace Application.Services.Interfaces
{
    public interface IRezervacijaService
    {
        Task<RezervacijaReturnable> AddRezervacijaAsync(RezervacijaCreate rezervacijaCreate);
        Task<bool> DeleteRezervacijaAsync(Guid id);
        Task<RezervacijaReturnable?> GetRezervacijaByIdAsync(Guid id);
        Task<IEnumerable<RezervacijaReturnable>> GetAllRezervacijeAsync();
        Task<RezervacijaReturnable> UpdateRezervacijaAsync(Guid id, RezervacijaUpdate rezervacijaUpdate);
        Task<IEnumerable<RezervacijaReturnable>> GetByFriIdAsync(Guid friId);
        Task<bool> RestartReservationAsync();
        Task<IEnumerable<ReservationWithStatus>> GetReservationsByDateAsync(DateTime date);
        Task<bool> CancelReservationAsync(Guid rezId, string email);

        Task<IEnumerable<ReservationWithStatus>> GetReservationsByFriIdAndDate(Guid friId, DateTime date);
    }
}