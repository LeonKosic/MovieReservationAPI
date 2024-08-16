using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace ScheduleReservationAPI.Services
{
    public class SchedulesService(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _context = dbContext;

        public async Task<ICollection<Schedule>> Get() =>
            await _context.Schedules.ToListAsync();

        public async Task<Schedule?> Get(int id) =>
            await _context.Schedules.FindAsync(id);

        public async Task Create(ScheduleDTO scheduleDTO)
        {
            Movie? movie = await _context.Movies.FindAsync(scheduleDTO.MovieId);
            if (movie == null) return; //todo
            Theater? theater = await _context.Theaters.FindAsync(scheduleDTO.TheaterId);
            if (theater == null) return;//todo
            Schedule schedule = new() { Movie = movie, Theater = theater, MovieId=scheduleDTO.MovieId, End= scheduleDTO.End, Start= scheduleDTO.Start, TheaterId=scheduleDTO.TheaterId, Time = scheduleDTO.Time}; 
            await _context.Schedules.AddAsync(schedule);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, ScheduleDTO updatedSchedule)
        {
            Schedule? Schedule = await _context.Schedules.FindAsync(id);
            if (Schedule is null) return;//todo
            Schedule.Start = updatedSchedule.Start;
            Schedule.End = updatedSchedule.End;
            Schedule.Time = updatedSchedule.Time;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Schedule? Schedule = await _context.Schedules.FindAsync(id);
            if (Schedule is null)
                return; //todo
            _context.Schedules.Remove(Schedule);
           await _context.SaveChangesAsync();
        }
    }
}
