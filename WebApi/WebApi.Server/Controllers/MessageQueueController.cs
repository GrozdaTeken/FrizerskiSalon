using Application.DTOs.Create;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessageQueueController : ControllerBase
    {
        private readonly IMessageQueueService _messageQueueService;

        public MessageQueueController(IMessageQueueService messageQueueService)
        {
            _messageQueueService = messageQueueService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var messageQueues = await _messageQueueService.GetAllMessageQueuesAsync();
            return Ok(messageQueues);
        }

        [HttpGet("GetMessageById/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var messageQueue = await _messageQueueService.GetMessageQueueByIdAsync(id);
            if (messageQueue == null) return NotFound();
            return Ok(messageQueue);
        }

        [HttpPost("AddMessage")]
        public async Task<IActionResult> Create(MessageQueueCreate messageQueueCreate)
        {
            var createdMessageQueue = await _messageQueueService.AddMessageQueueAsync(messageQueueCreate);
            return CreatedAtAction(nameof(GetById), new { id = createdMessageQueue.Id }, createdMessageQueue);
        }

        [HttpPut("UpdateMessageQueue/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, MessageQueueCreate messageQueueCreate)
        {
            await _messageQueueService.UpdateMessageQueueAsync(id, messageQueueCreate);
            return NoContent();
        }

        [HttpDelete("DeleteMessage/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _messageQueueService.DeleteMessageQueueAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}