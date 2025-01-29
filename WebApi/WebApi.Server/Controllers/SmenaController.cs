using Application.DTOs.Create;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class SmenaController : ControllerBase
    {
        private readonly ISmenaService _smenaService;

        public SmenaController(ISmenaService smenaService)
        {
            _smenaService = smenaService;
        }

        [HttpGet("SveSmene")]
        public async Task<IActionResult> GetAll()
        {
            var smene = await _smenaService.GetAllSmeneAsync();
            return Ok(smene);
        }

        [HttpGet("GetSmena/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var smena = await _smenaService.GetSmenaByIdAsync(id);
            if (smena == null) return NotFound();
            return Ok(smena);
        }

        [HttpPost("CreateSmena")]
        public async Task<IActionResult> Create(SmenaCreate smenaCreate)
        {
            var createdSmena = await _smenaService.AddSmenaAsync(smenaCreate);
            return CreatedAtAction(nameof(GetById), new { id = createdSmena.Id }, createdSmena);
        }

        [HttpPut("UpdateSmena/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, SmenaCreate smenaCreate)
        {
            await _smenaService.UpdateSmenaAsync(id, smenaCreate);
            return NoContent();
        }

        [HttpDelete("DeleteSmena/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _smenaService.DeleteSmenaAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("SmeneByFriId/{friId:guid}")]
        public async Task<IActionResult> GetSmeneByFriId(Guid friId)
        {
            var smene = await _smenaService.GetSmeneByFriIdAsync(friId);
            return Ok(smene);
        }

        [HttpPost("SetShift")]
        public async Task<IActionResult> SetShift(Guid friId, DateTime dateFrom, DateTime dateTo, TimeSpan shiftFrom, TimeSpan shiftTo)
        {
            await _smenaService.SetShiftAsync(friId, dateFrom, dateTo, shiftFrom, shiftTo);
            return Ok("Shift(s) added successfully.");
        }
    }
}
