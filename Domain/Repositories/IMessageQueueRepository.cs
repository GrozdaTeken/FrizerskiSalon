using Domain.Entities;

namespace Domain.Repositories
{
    public interface IMessageQueueRepository
    {
        Task AddAsync(MessageQueue messageQueue);
        Task<bool> DeleteAsync(Guid id);
        Task<MessageQueue?> GetByIdAsync(Guid id);
        Task<IEnumerable<MessageQueue>> GetAllAsync();
        Task UpdateAsync(MessageQueue messageQueue);
    }
}