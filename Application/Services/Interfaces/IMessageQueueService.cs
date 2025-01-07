using Application.DTOs.Create;
using Application.DTOs.Returnables;

namespace Application.Services.Interfaces
{
    public interface IMessageQueueService
    {
        Task<MessageQueueReturnable> AddMessageQueueAsync(MessageQueueCreate messageQueueCreate);
        Task<bool> DeleteMessageQueueAsync(Guid id);
        Task<MessageQueueReturnable?> GetMessageQueueByIdAsync(Guid id);
        Task<IEnumerable<MessageQueueReturnable>> GetAllMessageQueuesAsync();
        Task<MessageQueueReturnable> UpdateMessageQueueAsync(Guid id, MessageQueueCreate messageQueueCreate);
    }
}