using Domain.Entities;
using Application.DTOs.Returnable;
using Application.DTOs.Create;


namespace Application.Services.Interfaces
{
    public interface IFrizerService
    {
        Task<FrizerReturnable> AddFrizerAsync(FrizerCreate frizer);
        Task<bool> DeleteFrizerAsync(int id);
        Task<FrizerReturnable?> GetFrizerByIdAsync(int id);
        Task<IEnumerable<FrizerReturnable>> GetAllFrizersAsync();
        Task<FrizerReturnable> UpdateFrizerAsync(int friId, FrizerCreate frizer);
    }
}
