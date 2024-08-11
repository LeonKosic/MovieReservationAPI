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
    public class TheatersController(TheatersService theatersService) : ControllerBase
    {
        private readonly TheatersService _theatersService = theatersService;

        [HttpGet]
        public async Task<ICollection<Theater>> Get() =>
            await _theatersService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<Theater>> Get(int id)
        {
            var theater = await _theatersService.Get(id);
            if (theater == null)
            {
                return NotFound();
            }
            return theater;
        }
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(Theater theater)
        {
            await _theatersService.Create(theater);
            return CreatedAtAction(nameof(Get), theater);
        }

        [HttpPut("id"), Authorize]
        [OpenApiOperationProcessor(typeof(Theater))]
        public async Task<IActionResult> Update(int id, Theater updatedTheater)
        {
            try
            {
                await _theatersService.Update(id, updatedTheater);
                return Ok(updatedTheater);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Theater? theater = await _theatersService.Get(id);

            if (theater is null)
            {
                return NotFound();
            }

            await _theatersService.Delete(id);

            return NoContent();
        }
    }
}
}
