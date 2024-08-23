using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Data;
using Domain.Models.Entities;

namespace Infrastructure.Repositories
{
    public class SeatRepository(ApplicationDbContext dbContext) : BaseRepository<Seat>(dbContext), ISeatRepository
    {
    }
}
