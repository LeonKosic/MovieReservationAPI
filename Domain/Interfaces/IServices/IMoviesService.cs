using Domain.Models;
using Domain.Models.Entities;

namespace Domain.Interfaces.IServices
{
    public interface IMoviesService : IBaseService<Movie,MovieDTO>
    {
    }
}
