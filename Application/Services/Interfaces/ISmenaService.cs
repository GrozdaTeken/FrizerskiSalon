using Application.DTOs.Create;
using Application.DTOs.Returnables;

namespace Application.Services.Interfaces
{
    public interface ISmenaService
    {
        Task<SmenaReturnable> AddSmenaAsync(SmenaCreate smenaCreate);
        Task<bool> DeleteSmenaAsync(Guid id);
        Task<SmenaReturnable?> GetSmenaByIdAsync(Guid id);
        Task<IEnumerable<SmenaReturnable>> GetAllSmeneAsync();
        Task<SmenaReturnable> UpdateSmenaAsync(Guid id, SmenaCreate smenaCreate);
        Task<IEnumerable<SmenaReturnable>> GetSmeneByFriIdAsync(Guid friId);
    }
}