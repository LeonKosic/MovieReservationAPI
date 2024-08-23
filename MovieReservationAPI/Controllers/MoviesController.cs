using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Interfaces.IServices;
using Domain.Models;
using Domain.Results;
using Domain.Errors;
using MovieReservationAPI.Extensions;

namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController(IMoviesService moviesService) : ControllerBase
    {
        private readonly IMoviesService _moviesService = moviesService;

        [HttpGet]
        public async Task<ActionResult<ICollection<MovieDTO>>> Get()
        {
            var result = await _moviesService.Get();
            return result.Match<ActionResult<ICollection<MovieDTO>>>(
                    onSuccess: () => Ok(result),
                    onFailure: error => BadRequest(error));
        }

        [HttpGet("id")]
        public async Task<ActionResult<MovieDTO>> Get(int id)
        {
            var result = await _moviesService.Get(id);
            return result.Match<ActionResult<MovieDTO>>(
                    onSuccess: () => Ok(result),
                    onFailure: error => BadRequest(error));
        }
        [HttpPost, Authorize]
       
        public async Task<IActionResult> Post (MovieDTO movieDTO)
        {
            var result=await _moviesService.Create(movieDTO);
            return result.Match<IActionResult>(
                   onSuccess: () => CreatedAtAction(nameof(Get), movieDTO),
                   onFailure: error => BadRequest(error));
        }

        [HttpPut("id"), Authorize]
        public async Task<IActionResult> Update(int id, MovieDTO updatedMovie)
        {
            var result=await _moviesService.Update(id, updatedMovie);
            return result.Match<IActionResult>(
                   onSuccess: () => Ok(),
                   onFailure: error => BadRequest(error));
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var result=await _moviesService.Delete(id);
            return result.Match<IActionResult>(
                   onSuccess: () => Ok(),
                   onFailure: error => BadRequest(error));
        }
    }
}
