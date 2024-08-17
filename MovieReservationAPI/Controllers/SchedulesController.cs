using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservationAPI.Models;
using NSwag.Annotations;
using MovieReservationAPI.Interfaces.IServices;

namespace ScheduleReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController(IScheduleService schedulesService) : ControllerBase
    {
        private readonly IScheduleService _schedulesService = schedulesService;

        [HttpGet]
        public async Task<ICollection<ScheduleDTO>> Get() =>
            await _schedulesService.Get();

        [HttpGet("id")]
        public async Task<ActionResult<ScheduleDTO>> Get(int id)
        {
            return await _schedulesService.Get(id);
            
        }
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(ScheduleDTO scheduleDTO)
        {
            await _schedulesService.Create(scheduleDTO);
            return CreatedAtAction(nameof(Get), scheduleDTO);
        }

        [HttpPut("id"), Authorize]
        public async Task<IActionResult> Update(int id, ScheduleDTO updatedSchedule)
        {
            
            await _schedulesService.Update(id, updatedSchedule);
            return Ok(updatedSchedule);
           
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            await _schedulesService.Delete(id);

            return NoContent();
        }
    }
}
