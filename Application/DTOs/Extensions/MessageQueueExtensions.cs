using Application.DTOs.Create;
using Application.DTOs.Returnables;
using Domain.Entities;

namespace Application.DTOs.Extensions
{
    public static class MessageQueueExtensions
    {
        public static MessageQueue ConvertToEntity(this MessageQueueCreate dto)
        {
            return new MessageQueue
            {
                Id = Guid.NewGuid(),
                RezId = dto.RezId,
                Receiver = dto.Receiver,
                Sender = dto.Sender,
                Time = dto.Time,
                MessageSubject = dto.MessageSubject,
                Content = dto.Content,
                Status = dto.Status
            };
        }

        public static MessageQueueReturnable ConvertToReturnable(this MessageQueue entity)
        {
            return new MessageQueueReturnable
            {
                Id = entity.Id,
                RezId = entity.RezId,
                Receiver = entity.Receiver,
                Sender = entity.Sender,
                Time = entity.Time,
                MessageSubject = entity.MessageSubject,
                Content = entity.Content,
                Status = entity.Status
            };
        }
    }
}