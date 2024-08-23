using AutoMapper;
using Domain.Errors;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Results;
using System.Collections.Generic;

namespace Application.Services
{
    public class TheatersService(ITheaterRepository repository, IMapper mapper) : ITheatersService
    {
        private readonly ITheaterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
     
        public async Task<Result> Create(TheaterDTO newTheater)
        {
            var theater= _mapper.Map<Theater>(newTheater);
            await _repository.Create(theater);
            return Result.Success();
        }

        public async Task<Result> Delete(int id)
        {
            var theater = await _repository.Get(id);
            if(theater is null) return Result.Failure(Error.NotFound); 
            await _repository.Delete(theater);
            return Result.Success();
        }

        public async Task<Result<ICollection<TheaterDTO>>> Get()
        {
            var res = await _repository.Get();
            if (res is null) return Result<ICollection<TheaterDTO>>.Failure(Error.NotFound);
            var theaters = _mapper.Map<ICollection<TheaterDTO>>(res);
            return Result<ICollection<TheaterDTO>>.Success(theaters);
        }

        public async Task<Result<TheaterDTO>> Get(int id)
        {
            var theater = await _repository.Get(id);
            if(theater is null) return Result<TheaterDTO>.Failure(Error.NotFound);
            var theaterDTO = _mapper.Map<TheaterDTO>(theater);
            return Result<TheaterDTO>.Success(theaterDTO); 
        }


        public async Task<Result> Update(int id, TheaterDTO updatedTheater)
        {
            var theater = await _repository.Get(id);
            if (theater == null) return Result.Failure(Error.NotFound);
            _mapper.Map(updatedTheater,theater);
            await _repository.Save();
            return Result.Success();
        }
    }
}
