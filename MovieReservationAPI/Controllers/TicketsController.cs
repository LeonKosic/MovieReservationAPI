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
    public class TicketsController(TicketsService ticketsService) : ControllerBase
    {
        private readonly TicketsService _ticketsService = ticketsService;

        [HttpGet]
        public async Task<ICollection<Ticket>> Get() =>
            await _ticketsService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<Ticket>> Get(int id)
        {
            var ticket = await _ticketsService.Get(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return ticket;
        }
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(TicketDTO ticket)
        {
            await _ticketsService.Create(ticket);
            return CreatedAtAction(nameof(Get), ticket);
        }

        [HttpPut("id"), Authorize]
        [OpenApiOperationProcessor(typeof(Ticket))]
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
            Ticket? ticket = await _ticketsService.Get(id);

            if (ticket is null)
            {
                return NotFound();
            }

            await _ticketsService.Delete(id);

            return NoContent();
        }
    }
}

