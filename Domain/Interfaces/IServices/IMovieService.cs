using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Interfaces.IServices
{
    public interface IMovieService : IBaseService<Movie,MovieDTO>
    {
    }
}
