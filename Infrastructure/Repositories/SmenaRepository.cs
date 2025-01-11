using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SmenaRepository : ISmenaRepository
    {
        private readonly ApplicationDbContext _context;

        public SmenaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Smena smena)
        {
            _context.Smene.Add(smena);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var smena = await GetByIdAsync(id);
            if (smena == null) return false;

            _context.Smene.Remove(smena);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Smena?> GetByIdAsync(Guid id)
        {
            return await _context.Smene.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<Smena>> GetAllAsync()
        {
            return await _context.Smene.ToListAsync();
        }

        public async Task UpdateAsync(Smena smena)
        {
            _context.Smene.Update(smena);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Smena>> GetByFriIdAsync(Guid friId)
        {
            return await _context.Smene.Where(s => s.FriId == friId).ToListAsync();
        }
        public async Task SetShiftsAsync(IEnumerable<Smena> shifts)
        {
            await _context.Smene.AddRangeAsync(shifts);
            await _context.SaveChangesAsync();
        }

    }
}