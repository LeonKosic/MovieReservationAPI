using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class TheatersService(ITheaterRepository repository) : ITheatersService
    {
        private readonly ITheaterRepository _repository = repository;

        public Task Create(Theater newTheater)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TheaterDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TheaterDTO?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Theater updatedTheater)
        {
            throw new NotImplementedException();
        }
    }
}
