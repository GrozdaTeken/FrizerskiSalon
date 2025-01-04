using Application.Services.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FrizerController : ControllerBase
    {
        private readonly IFrizerService _frizerService;

        public FrizerController(IFrizerService frizerService)
        {
            _frizerService = frizerService;
        }

        [HttpGet("AllFrizers")]
        public async Task<IActionResult> GetAllFrizers()
        {
            var frizers = await _frizerService.GetAllFrizersAsync();
            return Ok(frizers);
        }

        [HttpGet("GetFrizer/{id}")]
        public async Task<IActionResult> GetFrizerById(int id)
        {
            var frizer = await _frizerService.GetFrizerByIdAsync(id);
            if (frizer == null) return NotFound();
            return Ok(frizer);
        }

        [HttpPost("AddFrizer")]
        public async Task<IActionResult> AddFrizer(Frizer frizer)
        {
            var createdFrizer = await _frizerService.AddFrizerAsync(frizer);
            return CreatedAtAction(nameof(GetFrizerById), new { id = createdFrizer.Id }, createdFrizer);
        }

        [HttpPut("UpdateFrizer/{id}")]
        public async Task<IActionResult> UpdateFrizer(int id, Frizer frizer)
        {
            if (id != frizer.Id) return BadRequest();
            await _frizerService.UpdateFrizerAsync(frizer);
            return NoContent();
        }

        [HttpDelete("DeleteFrizer/{id}")]
        public async Task<IActionResult> DeleteFrizer(int id)
        {
            var success = await _frizerService.DeleteFrizerAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
