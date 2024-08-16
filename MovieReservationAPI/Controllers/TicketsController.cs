using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;
using NSwag.Annotations;
using MovieReservationAPI.Interfaces.IServices;

namespace MovieReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(ITicketsService ticketsService) : ControllerBase
    {
        private readonly ITicketsService _ticketsService = ticketsService;

        [HttpGet]
        public async Task<ICollection<TicketDTO>> Get() =>
            await _ticketsService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<TicketDTO>> Get(int id)=>
            await _ticketsService.Get(id);
           
        
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(TicketDTO ticket)
        {
            await _ticketsService.Create(ticket);
            return CreatedAtAction(nameof(Get), ticket);
        }

        [HttpPut("id"), Authorize]
        public async Task<IActionResult> Update(int id, TicketDTO updatedTicket)
        {
            try
            {
                await _ticketsService.Update(id, updatedTicket);
                return Ok(updatedTicket);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            await _ticketsService.Delete(id);

            return NoContent();
        }
    }
}

