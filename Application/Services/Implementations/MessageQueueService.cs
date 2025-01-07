using Application.DTOs.Create;
using Application.DTOs.Extensions;
using Application.DTOs.Returnables;
using Application.Services.Interfaces;
using Domain.Repositories;

namespace Application.Services.Implementations
{
    public class MessageQueueService : IMessageQueueService
    {
        private readonly IMessageQueueRepository _messageQueueRepository;

        public MessageQueueService(IMessageQueueRepository messageQueueRepository)
        {
            _messageQueueRepository = messageQueueRepository;
        }

        public async Task<MessageQueueReturnable> AddMessageQueueAsync(MessageQueueCreate messageQueueCreate)
        {
            var messageQueue = messageQueueCreate.ConvertToEntity();
            await _messageQueueRepository.AddAsync(messageQueue);
            return messageQueue.ConvertToReturnable();
        }

        public async Task<bool> DeleteMessageQueueAsync(Guid id)
        {
            return await _messageQueueRepository.DeleteAsync(id);
        }

        public async Task<MessageQueueReturnable?> GetMessageQueueByIdAsync(Guid id)
        {
            var messageQueue = await _messageQueueRepository.GetByIdAsync(id);
            return messageQueue?.ConvertToReturnable();
        }

        public async Task<IEnumerable<MessageQueueReturnable>> GetAllMessageQueuesAsync()
        {
            var messageQueues = await _messageQueueRepository.GetAllAsync();
            return messageQueues.Select(mq => mq.ConvertToReturnable());
        }

        public async Task<MessageQueueReturnable> UpdateMessageQueueAsync(Guid id, MessageQueueCreate messageQueueCreate)
        {
            var existingMessageQueue = await _messageQueueRepository.GetByIdAsync(id);
            if (existingMessageQueue == null)
            {
                throw new Exception("MessageQueue not found.");
            }

            existingMessageQueue.RezId = messageQueueCreate.RezId;
            existingMessageQueue.Receiver = messageQueueCreate.Receiver;
            existingMessageQueue.Sender = messageQueueCreate.Sender;
            existingMessageQueue.Time = messageQueueCreate.Time;
            existingMessageQueue.MessageSubject = messageQueueCreate.MessageSubject;
            existingMessageQueue.Content = messageQueueCreate.Content;
            existingMessageQueue.Status = messageQueueCreate.Status;

            await _messageQueueRepository.UpdateAsync(existingMessageQueue);

            return existingMessageQueue.ConvertToReturnable();
        }
    }
}