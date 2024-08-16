using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;
using NSwag.Annotations;

namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IMoviesService moviesService) : ControllerBase
    {
        private readonly IMoviesService _moviesService = moviesService;

        [HttpGet]
        public async Task<ICollection<MovieDTO>> Get() =>
            await _moviesService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var movie = await _moviesService.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }
        [HttpPost, Authorize]
       
        public async Task<IActionResult> Post (MovieDTO movieDTO)
        {
            await _moviesService.Create(movieDTO);
            return CreatedAtAction(nameof(Get), movieDTO);
        }

        [HttpPut("id"), Authorize]
        public async Task<IActionResult> Update(int id, MovieDTO updatedMovie)
        {
            await _moviesService.Update(id, updatedMovie);
            return Ok(updatedMovie);
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _moviesService.Delete(id);
            return NoContent();
        }
    }
}
