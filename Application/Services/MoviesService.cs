using AutoMapper;
using Domain.Errors;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Results;

namespace Application.Services
{
    public class MoviesService(IMovieRepository repository,IMapper mapper) : IMoviesService
    {
        private readonly IMovieRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result> Create(MovieDTO newMovie)
        {
            Movie movie = _mapper.Map<Movie>(newMovie);
            await _repository.Create(movie);
            return Result.Success();
        }

        public async Task<Result> Delete(int id)
        {
            Movie? movie = await _repository.Get(id);    
            if(movie is null) return Result.Failure(Error.NotFound);
            await _repository.Delete(movie);
            return Result.Success();
        }

        public async Task<Result<ICollection<MovieDTO>>> Get()
        {
            var data= await _repository.Get();
            if (data is null) return Result<ICollection<MovieDTO>>.Failure(Error.NotFound);
            var movies = _mapper.Map<ICollection<MovieDTO>>(data);
            return Result < ICollection < MovieDTO >>.Success(movies);
        }

        public async Task<Result<MovieDTO>> Get(int id)
        {
            Movie? movie =await _repository.Get(id);
            if (movie is null) return Result<MovieDTO>.Failure(new Error("404","Movie does not exist"));
            var movieDTO = _mapper.Map<MovieDTO>(movie);
            return Result<MovieDTO>.Success(movieDTO);
        }

        public async Task<Result> Update(int id, MovieDTO updatedMovie)
        {
            Movie? movie = await _repository.Get(id);   
            if (movie is null) return Result.Failure(new Error("404","Movie does not exist"));
            _mapper.Map(updatedMovie, movie);
            await _repository.Save();
            return Result.Success();
        }
    }
}
