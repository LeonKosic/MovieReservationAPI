using AutoMapper;
using Domain.Errors;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Results;

namespace Application.Services
{
    public class SeatsService(ISeatRepository repository,IMapper mapper) : ISeatsService
    {
        private readonly ISeatRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result> Create(SeatDTO newSeat)
        {
            Seat seat = _mapper.Map<Seat>(newSeat);
            await _repository.Create(seat);
            return Result.Success();
        }

        public async Task<Result> Delete(int id)
        {
            var seat = await _repository.Get(id);
            if(seat is null) return Result.Failure(Error.NotFound);
            await _repository.Delete(seat);
            return Result.Success();
        }

        public async Task<Result<ICollection<SeatDTO>>> Get()
        {
            var result = await _repository.Get();
            if (result is null) return Result<ICollection<SeatDTO>>.Failure(Error.NotFound);
            var seats = _mapper.Map<ICollection<SeatDTO>>(result);
            return Result<ICollection<SeatDTO>>.Success(seats);
        }

        public async Task<Result<SeatDTO>> Get(int id)
        {
            var result = await _repository.Get(id);
            if(result is null) return Result<SeatDTO>.Failure(Error.NotFound);
            var seats = _mapper.Map<SeatDTO>(result);
            return Result<SeatDTO>.Success(seats);
        }

        public async Task<Result> Update(int id, SeatDTO updatedSeat)
        {
            Seat? seat = await _repository.Get(id);
            if (seat is null) return Result.Failure(Error.NotFound);
            _mapper.Map(updatedSeat,seat);
            await _repository.Save();
            return Result.Success();
        }
    }
}
