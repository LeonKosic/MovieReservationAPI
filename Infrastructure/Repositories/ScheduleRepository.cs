using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models.Entities;


namespace Infrastructure.Repositories
{
    public class ScheduleRepository(ApplicationDbContext dbContext) : BaseRepository<Schedule>(dbContext), IScheduleRepository
    {
    }
}
