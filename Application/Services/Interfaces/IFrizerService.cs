using Application.DTOs.Returnable;
using Application.DTOs.Create;


namespace Application.Services.Interfaces
{
    public interface IFrizerService
    {
        Task<FrizerReturnable> AddFrizerAsync(FrizerCreate frizer);
        Task<bool> DeleteFrizerAsync(Guid id);
        Task<FrizerReturnable?> GetFrizerByIdAsync(Guid id);
        Task<IEnumerable<FrizerReturnable>> GetAllFrizersAsync();
        Task<FrizerReturnable> UpdateFrizerAsync(Guid friId, FrizerCreate frizer);
    }
}
