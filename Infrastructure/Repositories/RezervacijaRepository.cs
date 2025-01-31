﻿using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RezervacijaRepository : IRezervacijaRepository
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rezervacija rezervacija)
        {
            _context.Rezervacije.Add(rezervacija);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var rezervacija = await GetByIdAsync(id);
            if (rezervacija == null) return false;

            _context.Rezervacije.Remove(rezervacija);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Rezervacija?> GetByIdAsync(Guid id)
        {
            return await _context.Rezervacije.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Rezervacija>> GetAllAsync()
        {
            return await _context.Rezervacije.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Rezervacija rezervacija)
        {
            _context.Rezervacije.Update(rezervacija);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }

        public async Task<IEnumerable<Rezervacija>> GetByFriIdAsync(Guid friId)
        {
            return await _context.Rezervacije.Where(r => r.FriId == friId).ToListAsync();
        }

        public async Task<bool> DeleteAllAsync()
        {
            var rezervacije = await _context.Rezervacije.ToListAsync();

            if (!rezervacije.Any())
            {
                return true;
            }

            _context.Rezervacije.RemoveRange(rezervacije);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Rezervacija>> GetReservationsByDateAsync(DateTime date)
        {
            return await _context.Rezervacije
                .Include(r => r.Frizer)
                .Where(r => r.Termin.Date == date.Date)
                .ToListAsync();
        }
        public async Task<bool> CancelReservationAsync(Guid rezId, string email)
        {
            var reservation = await _context.Rezervacije.FirstOrDefaultAsync(r => r.Id == rezId);

            if (reservation == null || reservation.Mail?.ToLower() != email.ToLower())
            {
                return false;
            }

            reservation.Ime = null;
            reservation.Mail = null;
            reservation.Telefon = null;

            return await UpdateAsync(reservation);
        }

        public async Task<IEnumerable<Rezervacija>> GetReservationsByFriIdAndDate(Guid friId, DateTime date)
        {
            return await _context.Rezervacije
                .Include(r => r.Frizer)
                .Where(r => r.Termin.Date == date.Date)
                .Where(r => r.FriId == friId)
                .ToListAsync();
        }
    }
}