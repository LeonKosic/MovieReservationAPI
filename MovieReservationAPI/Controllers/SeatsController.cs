using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Models.Entities;
using Domain.Models;
using Domain.Interfaces.IServices;
using MovieReservationAPI.Extensions;

namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController ( ISeatsService seatsService) : ControllerBase
    {
        private readonly ISeatsService _seatsService = seatsService;

        [HttpGet]
        public async Task<ActionResult<ICollection<SeatDTO>>> Get()
        {
            var result = await _seatsService.Get();
            return result.Match<ActionResult<ICollection<SeatDTO>>>(onSuccess: () => Ok(result), onFailure: err => NotFound(err));
        }

        [HttpGet("id")]
        public async Task<ActionResult<SeatDTO>> Get(int id)
        {
            var result = await _seatsService.Get(id);
            return result.Match<ActionResult<SeatDTO>>(onSuccess:()=>Ok(result), onFailure:err => NotFound(err));  
        }
            
        
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(SeatDTO seat)
        {
            var result = await _seatsService.Create(seat);
            return result.Match<IActionResult>(onSuccess:()=>Ok(result),onFailure:err=>NotFound(err)); 
        }

        [HttpPut("id"),Authorize]
        public async Task<IActionResult> Update(int id, SeatDTO seat)
        {
            var result=await _seatsService.Update(id, seat);
            return result.Match<IActionResult>(onSuccess:()=>Ok(result),onFailure: err=>NotFound(err));
        }

        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
         
            var result=await _seatsService.Delete(id);

            return result.Match<IActionResult>(onSuccess: () => Ok(result), onFailure: err => NotFound(err));
        }
    }
}
