using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MessageQueueRepository : IMessageQueueRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageQueueRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(MessageQueue messageQueue)
        {
            _context.MessageQueues.Add(messageQueue);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var messageQueue = await GetByIdAsync(id);
            if (messageQueue == null) return false;

            _context.MessageQueues.Remove(messageQueue);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<MessageQueue?> GetByIdAsync(Guid id)
        {
            return await _context.MessageQueues.FirstOrDefaultAsync(mq => mq.Id == id);
        }

        public async Task<IEnumerable<MessageQueue>> GetAllAsync()
        {
            return await _context.MessageQueues.ToListAsync();
        }

        public async Task UpdateAsync(MessageQueue messageQueue)
        {
            _context.MessageQueues.Update(messageQueue);
            await _context.SaveChangesAsync();
        }
    }
}