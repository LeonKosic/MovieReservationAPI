using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models.Entities;


namespace Infrastructure.Repositories
{
    public class TheaterRepository(ApplicationDbContext dbContext) : BaseRepository<Theater>(dbContext), ITheaterRepository
    {
    }
}
