using Application.DTOs.Create;
using Application.DTOs.Returnables;

namespace Application.Services.Interfaces
{
    public interface IGodisnjiService
    {
        Task<GodisnjiReturnable> AddGodisnjiAsync(GodisnjiCreate godisnjiCreate);
        Task<bool> DeleteGodisnjiAsync(Guid id);
        Task<GodisnjiReturnable?> GetGodisnjiByIdAsync(Guid id);
        Task<IEnumerable<GodisnjiReturnable>> GetAllGodisnjiAsync();
        Task<GodisnjiReturnable> UpdateGodisnjiAsync(Guid id, GodisnjiCreate godisnjiCreate);
        Task<IEnumerable<GodisnjiReturnable>> GetByFriIdAsync(Guid friId);
    }
}