using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Services;
using NSwag.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(MoviesService moviesService) : ControllerBase
    {
        private readonly MoviesService _moviesService = moviesService;

        [HttpGet]
        public async Task<ICollection<Movie>> Get() =>
            await _moviesService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<Movie>> Get(int id)
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
            Movie newMovie = new() { Name=movieDTO.Name, Description=movieDTO.Description, Duration=movieDTO.Duration, ReleaseDate=movieDTO.ReleaseDate };
            await _moviesService.Create(newMovie);
            return CreatedAtAction(nameof(Get), new {id = newMovie.Id}, newMovie);
        }

        [HttpPut("id"), Authorize]
        [OpenApiOperationProcessor(typeof(MovieDTO))]
        public async Task<IActionResult> Update(int id, Movie updatedMovie)
        {
            try
            {
                await _moviesService.Update(id, updatedMovie);
                return Ok(updatedMovie);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _moviesService.Get(id);

            if (book is null)
            {
                return NotFound();
            }

            await _moviesService.Delete(id);

            return NoContent();
        }
    }
}
