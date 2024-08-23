using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Data;
using Domain.Models.Entities;

namespace Infrastructure.Repositories
{
    public class MovieRepository(ApplicationDbContext dbContext) :BaseRepository<Movie>(dbContext) , IMovieRepository
    {
    }
}
