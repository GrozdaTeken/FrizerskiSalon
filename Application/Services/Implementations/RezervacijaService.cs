using Application.DTOs.Create;
using Application.DTOs.Extensions;
using Application.DTOs.Returnables;
using Application.DTOs.Update;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class RezervacijaService : IRezervacijaService
    {
        private readonly IRezervacijaRepository _rezervacijaRepository;
        private readonly ISmenaRepository _smenaRepository;

        public RezervacijaService(IRezervacijaRepository rezervacijaRepository, ISmenaRepository smenaRepository)
        {
            _rezervacijaRepository = rezervacijaRepository;
            _smenaRepository = smenaRepository;
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

        public async Task<RezervacijaReturnable> UpdateRezervacijaAsync(Guid id, RezervacijaUpdate rezervacijaUpdate)
        {
            var existingRezervacija = await _rezervacijaRepository.GetByIdAsync(id);
            if (existingRezervacija == null)
            {
                throw new Exception("Rezervacija not found.");
            }

            existingRezervacija.Ime = rezervacijaUpdate.Ime;
            existingRezervacija.Mail = rezervacijaUpdate.Mail;
            existingRezervacija.Telefon = rezervacijaUpdate.Telefon;

            await _rezervacijaRepository.UpdateAsync(existingRezervacija);

            return existingRezervacija.ConvertToReturnable();
        }


        public async Task<IEnumerable<RezervacijaReturnable>> GetByFriIdAsync(Guid friId)
        {
            var rezervacije = await _rezervacijaRepository.GetByFriIdAsync(friId);
            return rezervacije.Select(r => r.ConvertToReturnable());
        }

        public async Task<bool> RestartReservationAsync()
        {
            var deleteSuccess = await _rezervacijaRepository.DeleteAllAsync();

            if (!deleteSuccess)
            {
                return false;
            }

            var smene = await _smenaRepository.GetAllAsync();

            foreach (var smena in smene)
            {
                var pocetak = smena.Pocetak;
                var kraj = smena.Kraj;

                while (pocetak < kraj)
                {
                    var rezervacija = new Rezervacija
                    {
                        Id = Guid.NewGuid(),
                        FriId = smena.FriId,
                        Termin = pocetak,
                        Ime = null,
                        Mail = null,
                        Telefon = null
                    };

                    await _rezervacijaRepository.AddAsync(rezervacija);
                    pocetak = pocetak.AddMinutes(20);
                }
            }

            return true;
        }

        public async Task<IEnumerable<ReservationWithStatus>> GetReservationsByDateAsync(DateTime date)
        {
            var reservations = await _rezervacijaRepository.GetReservationsByDateAsync(date);

            return reservations.Select(r => new ReservationWithStatus
            {
                Id = r.Id,
                FriId = r.FriId,
                FrizerName = r.Frizer.Ime + " " + r.Frizer.Prezime,
                Termin = r.Termin,
                Occupied = !(string.IsNullOrEmpty(r.Ime) && string.IsNullOrEmpty(r.Mail) && string.IsNullOrEmpty(r.Telefon))
            });
        }
    }
}