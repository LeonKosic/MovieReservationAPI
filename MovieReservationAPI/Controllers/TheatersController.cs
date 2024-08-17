using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models.Entities;
using NSwag.Annotations;
using MovieReservationAPI.Models;
using MovieReservationAPI.Interfaces.IServices;
namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheatersController(ITheaterService theatersService) : ControllerBase
    {
        private readonly ITheaterService _theatersService = theatersService;

        [HttpGet]
        public async Task<ICollection<TheaterDTO>> Get() =>
            await _theatersService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<TheaterDTO>> Get(int id)=> 
            await _theatersService.Get(id);
        
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(TheaterDTO theater)
        {
            await _theatersService.Create(theater);
            return CreatedAtAction(nameof(Get), theater);
        }

        [HttpPut("id"), Authorize]
        public async Task<IActionResult> Update(int id, TheaterDTO updatedTheater)
        {
            await _theatersService.Update(id, updatedTheater);
            return Ok(updatedTheater);
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _theatersService.Delete(id);
            return NoContent();
        }
    }
}

