using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;
using NSwag.Annotations;
using MovieReservationAPI.Services;

namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController ( SeatsService seatsService) : ControllerBase
    {
        private readonly SeatsService _seatsService = seatsService;

        [HttpGet]
        public async Task<ICollection<Seat>> Get() =>
            await _seatsService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<Seat>> Get(int id)
        {
            var seat = await _seatsService.Get(id);
            if (seat == null)
            {
                return NotFound();
            }
            return seat;
        }
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(SeatDTO seat)
        {
            await _seatsService.Create(seat);
            return CreatedAtAction(nameof(Get), seat);
        }

        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Seat? seat = await _seatsService.Get(id);

            if (seat is null)
            {
                return NotFound();
            }

            await _seatsService.Delete(id);

            return NoContent();
        }
    }
}
