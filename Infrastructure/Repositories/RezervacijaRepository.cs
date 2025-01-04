using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class RezervacijaRepository : IRezervacijaRepository
    {
        private readonly ApplicationDbContext _context;

        public RezervacijaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Rezervacija>> GetAllAsync()
        {
            return await _context.Rezervacije.ToListAsync();
        }

        public async Task<Rezervacija> GetByIdAsync(int rezId)
        {
            return await _context.Rezervacije.FindAsync(rezId);
        }

        public async Task AddAsync(Rezervacija rezervacija)
        {
            await _context.Rezervacije.AddAsync(rezervacija);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Rezervacija rezervacija)
        {
            _context.Rezervacije.Update(rezervacija);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int rezId)
        {
            var rezervacija = await GetByIdAsync(rezId);
            if (rezervacija != null)
            {
                _context.Rezervacije.Remove(rezervacija);
                await _context.SaveChangesAsync();
            }
        }
    }
}
