using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace ScheduleReservationAPI.Services
{
    public class SchedulesService(IScheduleRepository repository) : ISchedulesService
    {
        private readonly IScheduleRepository _repository = repository;

        public Task Create(Schedule newSchedule)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ScheduleDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<ScheduleDTO?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Schedule updatedSchedule)
        {
            throw new NotImplementedException();
        }
    }
}
