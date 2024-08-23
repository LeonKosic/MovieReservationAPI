using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Domain.Models;
using NSwag.Annotations;
using Domain.Interfaces.IServices;
using MovieReservationAPI.Extensions;

namespace ScheduleReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController(ISchedulesService schedulesService) : ControllerBase
    {
        private readonly ISchedulesService _schedulesService = schedulesService;

        [HttpGet]
        public async Task<ActionResult<ICollection<ScheduleDTO>>> Get()
        {
            var result=await _schedulesService.Get();
            return result.Match<ActionResult<ICollection<ScheduleDTO>>>(
                onSuccess:()=>Ok(result),
                onFailure:err=>BadRequest(err));
        }

        [HttpGet("id")]
        public async Task<ActionResult<ScheduleDTO>> Get(int id)
        {
            var result= await _schedulesService.Get(id);
            return result.Match<ActionResult<ScheduleDTO>>(
                onSuccess: () => Ok(result),
                onFailure: err => BadRequest(err));
            
        }
        [HttpPost, Authorize]

        public async Task<IActionResult> Post(ScheduleDTO scheduleDTO)
        {
            var result = await _schedulesService.Create(scheduleDTO);
            return result.Match<IActionResult>(onSuccess: () => Ok(result),onFailure:err=>BadRequest(err));
        }

        [HttpPut("id"), Authorize]
        public async Task<IActionResult> Update(int id, ScheduleDTO updatedSchedule)
        {
            
            var result = await _schedulesService.Update(id, updatedSchedule);
            return result.Match<IActionResult>(onSuccess:()=> Ok(result),onFailure: err=>BadRequest(err));
           
        }
        [HttpDelete("id"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {

            var result=await _schedulesService.Delete(id);

            return result.Match<IActionResult>(onSuccess: () => Ok(result), onFailure: err => BadRequest(err));
        }
    }
}
