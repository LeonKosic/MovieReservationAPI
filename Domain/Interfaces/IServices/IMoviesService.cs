using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Interfaces.IServices
{
    public interface IMoviesService : IBaseService<Movie,MovieDTO>
    {
    }
}
