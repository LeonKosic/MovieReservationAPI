using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;
using MovieReservationAPI.Interfaces.IServices;

namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController ( ISeatService seatsService) : ControllerBase
    {
        private readonly ISeatService _seatsService = seatsService;

        [HttpGet]
        public async Task<ICollection<SeatDTO>> Get() =>
            await _seatsService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<SeatDTO>> Get(int id) => 
            await _seatsService.Get(id);
            
        
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(SeatDTO seat)
        {
            await _seatsService.Create(seat);
            return CreatedAtAction(nameof(Get), seat);
        }

        [HttpPut("id"),Authorize]
        public async Task<IActionResult> Update(int id, SeatDTO seat)
        {
            await _seatsService.Update(id, seat);
            return Ok(seat);
        }

        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
         
            await _seatsService.Delete(id);

            return NoContent();
        }
    }
}
