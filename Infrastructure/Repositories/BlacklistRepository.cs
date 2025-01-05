
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BlacklistRepository : IBlacklistRepository
    {
        private readonly ApplicationDbContext _context;

        public BlacklistRepository(ApplicationDbContext context) { _context = context; }

        public async Task<Blacklist> AddToBlacklistAsync(Blacklist blacklist)
        {
            _context.Blacklists.Add(blacklist);
            await _context.SaveChangesAsync();
            return blacklist;
        }

        public async Task<bool> RemoveFromBlacklistAsync(Guid id)
        {
            var blacklist = await GetBlacklistedInfoAsync(id);
            if(blacklist == null) return false;

            _context.Blacklists.Remove(blacklist);

            return await _context.SaveChangesAsync() > 0; 
        }

        public async Task<Blacklist?> GetBlacklistedInfoAsync(Guid id)
        {
            return await _context.Blacklists.FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Blacklist>> GetAllBlacklistedAsync()
        {
            return await _context.Blacklists.ToListAsync();
        }

        public async Task UpdateBlacklistAsync(Blacklist blacklist)
        {
            _context.Blacklists.Update(blacklist);
            await _context.SaveChangesAsync();
        }
    }
}
