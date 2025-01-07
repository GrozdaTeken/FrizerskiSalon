using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class GodisnjiRepository : IGodisnjiRepository
    {
        private readonly ApplicationDbContext _context;

        public GodisnjiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Godisnji godisnji)
        {
            _context.Godisnji.Add(godisnji);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var godisnji = await GetByIdAsync(id);
            if (godisnji == null) return false;

            _context.Godisnji.Remove(godisnji);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Godisnji?> GetByIdAsync(Guid id)
        {
            return await _context.Godisnji.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<IEnumerable<Godisnji>> GetAllAsync()
        {
            return await _context.Godisnji.ToListAsync();
        }

        public async Task UpdateAsync(Godisnji godisnji)
        {
            _context.Godisnji.Update(godisnji);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Godisnji>> GetByFriIdAsync(Guid friId)
        {
            return await _context.Godisnji.Where(g => g.FriId == friId).ToListAsync();
        }
    }
}