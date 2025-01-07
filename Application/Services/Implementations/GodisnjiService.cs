using Application.DTOs.Create;
using Application.DTOs.Extensions;
using Application.DTOs.Returnables;
using Application.Services.Interfaces;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class GodisnjiService : IGodisnjiService
    {
        private readonly IGodisnjiRepository _godisnjiRepository;

        public GodisnjiService(IGodisnjiRepository godisnjiRepository)
        {
            _godisnjiRepository = godisnjiRepository;
        }

        public async Task<GodisnjiReturnable> AddGodisnjiAsync(GodisnjiCreate godisnjiCreate)
        {
            var godisnji = godisnjiCreate.ConvertToEntity();
            await _godisnjiRepository.AddAsync(godisnji);
            return godisnji.ConvertToReturnable();
        }

        public async Task<bool> DeleteGodisnjiAsync(Guid id)
        {
            return await _godisnjiRepository.DeleteAsync(id);
        }

        public async Task<GodisnjiReturnable?> GetGodisnjiByIdAsync(Guid id)
        {
            var godisnji = await _godisnjiRepository.GetByIdAsync(id);
            return godisnji?.ConvertToReturnable();
        }

        public async Task<IEnumerable<GodisnjiReturnable>> GetAllGodisnjiAsync()
        {
            var godisnjiList = await _godisnjiRepository.GetAllAsync();
            return godisnjiList.Select(g => g.ConvertToReturnable());
        }

        public async Task<GodisnjiReturnable> UpdateGodisnjiAsync(Guid id, GodisnjiCreate godisnjiCreate)
        {
            var existingGodisnji = await _godisnjiRepository.GetByIdAsync(id);
            if (existingGodisnji == null)
            {
                throw new Exception("Godisnji not found.");
            }

            existingGodisnji.FriId = godisnjiCreate.FriId;
            existingGodisnji.GodisnjiOd = godisnjiCreate.GodisnjiOd;
            existingGodisnji.GodisnjiDo = godisnjiCreate.GodisnjiDo;

            await _godisnjiRepository.UpdateAsync(existingGodisnji);

            return existingGodisnji.ConvertToReturnable();
        }

        public async Task<IEnumerable<GodisnjiReturnable>> GetByFriIdAsync(Guid friId)
        {
            var godisnjiList = await _godisnjiRepository.GetByFriIdAsync(friId);
            return godisnjiList.Select(g => g.ConvertToReturnable());
        }
    }
}