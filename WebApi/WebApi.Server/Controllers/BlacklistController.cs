using Application.DTOs.Create;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlacklistController : ControllerBase
    {
        private readonly IBlacklistService _blacklistService;

        public BlacklistController(IBlacklistService blacklistService)
        {
            _blacklistService = blacklistService;
        }

        [HttpGet("AllOnBlacklist")]
        public async Task<IActionResult> GetAllFromBlacklist()
        {
            var blacklists = await _blacklistService.GetBlacklistsAsync();
            return Ok(blacklists);
        }

        [HttpGet("GetBlacklist/{id}")]
        public async Task<IActionResult> GetBlacklistById(Guid id)
        {
            var blacklist = await _blacklistService.GetBlacklistByIdAsync(id);
            if (blacklist == null) return NotFound();
            return Ok(blacklist);
        }

        [HttpPost("AddToBlacklist")]
        public async Task<IActionResult> AddToBlacklist(BlacklistCreate blacklistCreate)
        {
            var createdBlacklist = await _blacklistService.AddBlacklistAsync(blacklistCreate);
            return CreatedAtAction(nameof(GetBlacklistById), new { id = createdBlacklist.Id }, createdBlacklist);
        }

        [HttpPut("UpdateBlacklist/{id}")]
        public async Task<IActionResult> UpdateBlacklist(Guid id, BlacklistCreate blacklistCreate)
        {
            await _blacklistService.UpdateBlacklistAsync(id, blacklistCreate);
            return NoContent();
        }

        [HttpDelete("DeleteFromBlacklist/{id}")]
        public async Task<IActionResult> DeleteFromBlacklist(Guid id)
        {
            var success = await _blacklistService.DeleteBlacklistAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
