using Application.DTOs.Create;
using Application.DTOs.Extensions;
using Application.DTOs.Returnables;
using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class BlacklistService : IBlacklistService
    {
        private readonly IBlacklistRepository _blacklistRepository;

        public BlacklistService(IBlacklistRepository blacklistRepository)
        {
            _blacklistRepository = blacklistRepository;
        }

        public async Task<BlacklistReturnable> AddBlacklistAsync(BlacklistCreate blacklistCreate)
        {
            Blacklist blacklist = blacklistCreate.ConvertToEntity();

            try
            {
                await _blacklistRepository.AddToBlacklistAsync(blacklist);

                BlacklistReturnable blacklistReturnable = blacklist.ConvertToReturnable();

                return blacklistReturnable;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Failed to add to blacklist.", ex);
            }
        }

        public async Task<bool> DeleteBlacklistAsync(Guid id)
        {
            return await _blacklistRepository.RemoveFromBlacklistAsync(id);
        }

        public async Task<BlacklistReturnable?> GetBlacklistByIdAsync(Guid id)
        {
            var blacklist = await _blacklistRepository.GetBlacklistedInfoAsync(id);

            return blacklist.ConvertToReturnable() ?? null;
        }

        public async Task<IEnumerable<BlacklistReturnable>> GetBlacklistsAsync()
        {
            var blacklists = await _blacklistRepository.GetAllBlacklistedAsync();
            return blacklists.Select(x => x.ConvertToReturnable());
        }

        public async Task<BlacklistReturnable> UpdateBlacklistAsync(Guid id, BlacklistCreate blacklistCreate)
        {
            var existingBlacklist = await _blacklistRepository.GetBlacklistedInfoAsync(id);

            if (existingBlacklist != null)
            {
                throw new Exception("Blacklist doesn't exist.");
            }

            existingBlacklist.Email = blacklistCreate.Email;
            existingBlacklist.Telefon = blacklistCreate.Telefon;
            existingBlacklist.Razlog = blacklistCreate.Razlog;
            existingBlacklist.CreatedAt = blacklistCreate.CreatedAt;

            await _blacklistRepository.UpdateBlacklistAsync(existingBlacklist);

            return existingBlacklist.ConvertToReturnable();
        }
    }
}