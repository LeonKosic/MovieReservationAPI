
using AutoMapper;
using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class SeatsService(ISeatRepository repository,IMapper mapper) : ISeatsService
    {
        private readonly ISeatRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task Create(SeatDTO newSeat)
        {
            Seat seat = _mapper.Map<Seat>(newSeat);
            await _repository.Create(seat);
        }

        public async Task Delete(int id)
        {
            var seat = await _repository.Get(id);
            if(seat!=null)
                     await _repository.Delete(seat);
        }

        public async Task<ICollection<SeatDTO>> Get()
        {
            return _mapper.Map<ICollection<SeatDTO>>(await _repository.Get());
        }

        public async Task<SeatDTO?> Get(int id)
        {
            return _mapper.Map<SeatDTO>(await _repository.Get(id)); 
        }

        public async Task Update(int id, SeatDTO updatedSeat)
        {
            Seat? seat = await _repository.Get(id);
            if (seat is null) return;
            _mapper.Map(updatedSeat,seat);
            await _repository.Save();
        }
    }
}
