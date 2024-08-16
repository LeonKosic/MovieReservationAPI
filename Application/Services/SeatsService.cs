
using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class SeatsService(ISeatRepository repository) : ISeatsService
    {
        private readonly ISeatRepository _repository = repository;

        public Task Create(Seat newSeat)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<SeatDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<SeatDTO?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Seat updatedSeat)
        {
            throw new NotImplementedException();
        }
    }
}
