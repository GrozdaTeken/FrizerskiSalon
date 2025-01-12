using Application.DTOs.Create;
using Application.DTOs.Update;
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
        public async Task<IActionResult> Update(Guid id, RezervacijaUpdate rezervacijaUpdate)
        {
            await _rezervacijaService.UpdateRezervacijaAsync(id, rezervacijaUpdate);
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

        [HttpPost("RestartReservation")]
        public async Task<IActionResult> RestartReservation()
        {
            var success = await _rezervacijaService.RestartReservationAsync();
            if (!success)
            {
                return StatusCode(500, "Error during reservation restart.");
            }

            return Ok("Reservations have been successfully restarted.");
        }

        [HttpGet("ShowReservations/{date}")]
        public async Task<IActionResult> ShowReservations(DateTime date)
        {
            var reservations = await _rezervacijaService.GetReservationsByDateAsync(date);
            return Ok(reservations);
        }

        [HttpPut("CancelReservation/{rezId:guid}")]
        public async Task<IActionResult> CancelReservation(Guid rezId)
        {
            var success = await _rezervacijaService.CancelReservationAsync(rezId);

            if (!success)
            {
                return NotFound("Reservation not found or cancellation failed.");
            }

            return Ok("Reservation successfully cancelled.");
        }
    }
}