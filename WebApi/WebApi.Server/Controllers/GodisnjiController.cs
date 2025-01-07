using Application.DTOs.Create;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GodisnjiController : ControllerBase
    {
        private readonly IGodisnjiService _godisnjiService;

        public GodisnjiController(IGodisnjiService godisnjiService)
        {
            _godisnjiService = godisnjiService;
        }

        [HttpGet("allGodisnji")]
        public async Task<IActionResult> GetAll()
        {
            var godisnjiList = await _godisnjiService.GetAllGodisnjiAsync();
            return Ok(godisnjiList);
        }

        [HttpGet("getGodisnji/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var godisnji = await _godisnjiService.GetGodisnjiByIdAsync(id);
            if (godisnji == null) return NotFound();
            return Ok(godisnji);
        }

        [HttpPost("AddGodisnji")]
        public async Task<IActionResult> Create(GodisnjiCreate godisnjiCreate)
        {
            var createdGodisnji = await _godisnjiService.AddGodisnjiAsync(godisnjiCreate);
            return CreatedAtAction(nameof(GetById), new { id = createdGodisnji.Id }, createdGodisnji);
        }

        [HttpPut("UpdateGodisnji/{id}")]
        public async Task<IActionResult> Update(Guid id, GodisnjiCreate godisnjiCreate)
        {
            await _godisnjiService.UpdateGodisnjiAsync(id, godisnjiCreate);
            return NoContent();
        }

        [HttpDelete("DeleteGodisnji/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _godisnjiService.DeleteGodisnjiAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("GetGodisnjiForFrizer/{friId:guid}")]
        public async Task<IActionResult> GetByFriId(Guid friId)
        {
            var godisnjiList = await _godisnjiService.GetByFriIdAsync(friId);
            return Ok(godisnjiList);
        }
    }
}