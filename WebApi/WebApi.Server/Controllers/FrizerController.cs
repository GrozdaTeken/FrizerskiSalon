using Application.DTOs.Create;
using Application.Services.Interfaces;
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
        public async Task<IActionResult> GetFrizerById(Guid id)
        {
            var frizer = await _frizerService.GetFrizerByIdAsync(id);
            if (frizer == null) return NotFound();
            return Ok(frizer);
        }

        [HttpPost("AddFrizer")]
        public async Task<IActionResult> AddFrizer(FrizerCreate frizerCreate)
        {
            var createdFrizer = await _frizerService.AddFrizerAsync(frizerCreate);
            return CreatedAtAction(nameof(GetFrizerById), new { id = createdFrizer.Id }, createdFrizer);
        }

        [HttpPut("UpdateFrizer/{id}")]
        public async Task<IActionResult> UpdateFrizer(Guid id, FrizerCreate frizerCreate)
        {
            await _frizerService.UpdateFrizerAsync(id, frizerCreate);
            return NoContent();
        }

        [HttpDelete("DeleteFrizer/{id}")]
        public async Task<IActionResult> DeleteFrizer(Guid id)
        {
            var success = await _frizerService.DeleteFrizerAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }
    }
}
