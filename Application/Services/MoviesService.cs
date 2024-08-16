using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class MoviesService(IMovieRepository repository) : IMoviesService
    {
        private readonly IMovieRepository _repository = repository;

        public Task Create(Movie newMovie)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MovieDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<MovieDTO?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Movie updatedMovie)
        {
            throw new NotImplementedException();
        }
    }
}
