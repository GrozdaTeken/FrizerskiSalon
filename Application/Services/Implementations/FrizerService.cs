using Application.Services.Interfaces;
using Domain.Entities;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class FrizerService : IFrizerService
    {
        private readonly IFrizerRepository _frizerRepository;

        public FrizerService(IFrizerRepository frizerRepository)
        {
            _frizerRepository = frizerRepository;
        }

        public async Task<Frizer> AddFrizerAsync(Frizer frizer)
        {
            return await _frizerRepository.AddFrizerAsync(frizer);
        }

        public async Task<bool> DeleteFrizerAsync(int id)
        {
            return await _frizerRepository.DeleteFrizerAsync(id);
        }

        public async Task<Frizer?> GetFrizerByIdAsync(int id)
        {
            return await _frizerRepository.GetFrizerByIdAsync(id);
        }

        public async Task<IEnumerable<Frizer>> GetAllFrizersAsync()
        {
            return await _frizerRepository.GetAllFrizersAsync();
        }

        public async Task UpdateFrizerAsync(Frizer frizer)
        {
            await _frizerRepository.UpdateFrizerAsync(frizer);
        }
    }
}
