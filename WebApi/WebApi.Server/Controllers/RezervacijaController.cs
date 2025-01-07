using Application.DTOs.Create;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RezervacijaController : ControllerBase
    {
        private readonly IRezervacijaService _rezervacijaService;

        public RezervacijaController(IRezervacijaService rezervacijaService)
        {
            _rezervacijaService = rezervacijaService;
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            var rezervacije = await _rezervacijaService.GetAllRezervacijeAsync();
            return Ok(rezervacije);
        }

        [HttpGet("GetRezervacija/{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var rezervacija = await _rezervacijaService.GetRezervacijaByIdAsync(id);
            if (rezervacija == null) return NotFound();
            return Ok(rezervacija);
        }

        [HttpPost("AddRezervacija")]
        public async Task<IActionResult> Create(RezervacijaCreate rezervacijaCreate)
        {
            var createdRezervacija = await _rezervacijaService.AddRezervacijaAsync(rezervacijaCreate);
            return CreatedAtAction(nameof(GetById), new { id = createdRezervacija.Id }, createdRezervacija);
        }

        [HttpPut("UpdateRezervacija/{id:guid}")]
        public async Task<IActionResult> Update(Guid id, RezervacijaCreate rezervacijaCreate)
        {
            await _rezervacijaService.UpdateRezervacijaAsync(id, rezervacijaCreate);
            return NoContent();
        }

        [HttpDelete("DeleteRezervacija/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var success = await _rezervacijaService.DeleteRezervacijaAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpGet("RezervacijeZaFrizera/{friId:guid}")]
        public async Task<IActionResult> GetByFriId(Guid friId)
        {
            var rezervacije = await _rezervacijaService.GetByFriIdAsync(friId);
            return Ok(rezervacije);
        }
    }
}