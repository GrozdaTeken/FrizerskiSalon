using Application.DTOs.Create;
using Application.DTOs.Returnables;

namespace Application.Services.Interfaces
{
    public interface IRezervacijaService
    {
        Task<RezervacijaReturnable> AddRezervacijaAsync(RezervacijaCreate rezervacijaCreate);
        Task<bool> DeleteRezervacijaAsync(Guid id);
        Task<RezervacijaReturnable?> GetRezervacijaByIdAsync(Guid id);
        Task<IEnumerable<RezervacijaReturnable>> GetAllRezervacijeAsync();
        Task<RezervacijaReturnable> UpdateRezervacijaAsync(Guid id, RezervacijaCreate rezervacijaCreate);
        Task<IEnumerable<RezervacijaReturnable>> GetByFriIdAsync(Guid friId);
    }
}