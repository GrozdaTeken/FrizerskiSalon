using Application.DTOs.Create;
using Application.DTOs.Extensions;
using Application.DTOs.Returnables;
using Application.Services.Interfaces;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class RezervacijaService : IRezervacijaService
    {
        private readonly IRezervacijaRepository _rezervacijaRepository;

        public RezervacijaService(IRezervacijaRepository rezervacijaRepository)
        {
            _rezervacijaRepository = rezervacijaRepository;
        }

        public async Task<RezervacijaReturnable> AddRezervacijaAsync(RezervacijaCreate rezervacijaCreate)
        {
            var rezervacija = rezervacijaCreate.ConvertToEntity();
            await _rezervacijaRepository.AddAsync(rezervacija);
            return rezervacija.ConvertToReturnable();
        }

        public async Task<bool> DeleteRezervacijaAsync(Guid id)
        {
            return await _rezervacijaRepository.DeleteAsync(id);
        }

        public async Task<RezervacijaReturnable?> GetRezervacijaByIdAsync(Guid id)
        {
            var rezervacija = await _rezervacijaRepository.GetByIdAsync(id);
            return rezervacija?.ConvertToReturnable();
        }

        public async Task<IEnumerable<RezervacijaReturnable>> GetAllRezervacijeAsync()
        {
            var rezervacije = await _rezervacijaRepository.GetAllAsync();
            return rezervacije.Select(r => r.ConvertToReturnable());
        }

        public async Task<RezervacijaReturnable> UpdateRezervacijaAsync(Guid id, RezervacijaCreate rezervacijaCreate)
        {
            var existingRezervacija = await _rezervacijaRepository.GetByIdAsync(id);
            if (existingRezervacija == null)
            {
                throw new Exception("Rezervacija not found.");
            }

            existingRezervacija.FriId = rezervacijaCreate.FriId;
            existingRezervacija.Termin = rezervacijaCreate.Termin;
            existingRezervacija.Ime = rezervacijaCreate.Ime;
            existingRezervacija.Mail = rezervacijaCreate.Mail;
            existingRezervacija.Telefon = rezervacijaCreate.Telefon;

            await _rezervacijaRepository.UpdateAsync(existingRezervacija);

            return existingRezervacija.ConvertToReturnable();
        }

        public async Task<IEnumerable<RezervacijaReturnable>> GetByFriIdAsync(Guid friId)
        {
            var rezervacije = await _rezervacijaRepository.GetByFriIdAsync(friId);
            return rezervacije.Select(r => r.ConvertToReturnable());
        }
    }
}