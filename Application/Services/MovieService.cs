using AutoMapper;
using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class MovieService(IMovieRepository repository,IMapper mapper) : IMovieService
    {
        private readonly IMovieRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task Create(MovieDTO newMovie)
        {
            Movie movie = _mapper.Map<Movie>(newMovie);
            await _repository.Create(movie);
        }

        public async Task Delete(int id)
        {
            Movie? movie = await _repository.Get(id);    
            if(movie is not null)await _repository.Delete(movie);
        }

        public async Task<ICollection<MovieDTO>> Get()
        {
            return  _mapper.Map<ICollection<MovieDTO>>(await _repository.Get());
        }

        public async Task<MovieDTO?> Get(int id)
        {
            Movie? movie =await _repository.Get(id);
            if (movie is null) return null;
            return _mapper.Map<MovieDTO>(movie);
        }

        public async Task Update(int id, MovieDTO updatedMovie)
        {
            Movie? movie = await _repository.Get(id);   
            if (movie is null) return;
            _mapper.Map(updatedMovie, movie);
            await _repository.Save();
        }
    }
}
