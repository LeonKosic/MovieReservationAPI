using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;
using ScheduleReservationAPI.Services;
using NSwag.Annotations;

namespace ScheduleReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController(SchedulesService schedulesService) : ControllerBase
    {
        private readonly SchedulesService _schedulesService = schedulesService;

        [HttpGet]
        public async Task<ICollection<Schedule>> Get() =>
            await _schedulesService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<Schedule>> Get(int id)
        {
            var schedule = await _schedulesService.Get(id);
            if (schedule == null)
            {
                return NotFound();
            }
            return schedule;
        }
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(ScheduleDTO schedule)
        {
            await _schedulesService.Create(schedule);
            return CreatedAtAction(nameof(Get), schedule);
        }

        [HttpPut("id"), Authorize]
        [OpenApiOperationProcessor(typeof(Schedule))]
        public async Task<IActionResult> Update(int id, ScheduleDTO updatedSchedule)
        {
            try
            {
                await _schedulesService.Update(id, updatedSchedule);
                return Ok(updatedSchedule);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Schedule? schedule = await _schedulesService.Get(id);

            if (schedule is null)
            {
                return NotFound();
            }

            await _schedulesService.Delete(id);

            return NoContent();
        }
    }
}
