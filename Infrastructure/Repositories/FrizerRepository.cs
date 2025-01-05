using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class FrizerRepository : IFrizerRepository
    {
        private readonly ApplicationDbContext _context;

        public FrizerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Frizer> AddFrizerAsync(Frizer frizer)
        {
            _context.Frizeri.Add(frizer);
            await _context.SaveChangesAsync();
            return frizer;
        }

        public async Task<bool> DeleteFrizerAsync(Guid id)
        {
            var frizer = await GetFrizerByIdAsync(id);
            if (frizer == null) return false;

            _context.Frizeri.Remove(frizer);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Frizer?> GetFrizerByIdAsync(Guid id)
        {
            return await _context.Frizeri.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Frizer>> GetAllFrizersAsync()
        {
            return await _context.Frizeri.ToListAsync();
        }

        public async Task UpdateFrizerAsync(Frizer frizer)
        {
            _context.Frizeri.Update(frizer);
            await _context.SaveChangesAsync();
        }
    }
}