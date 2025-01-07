using Domain.Entities;
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

        public async Task UpdateAsync(Rezervacija rezervacija)
        {
            _context.Rezervacije.Update(rezervacija);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Rezervacija>> GetByFriIdAsync(Guid friId)
        {
            return await _context.Rezervacije.Where(r => r.FriId == friId).ToListAsync();
        }
    }
}