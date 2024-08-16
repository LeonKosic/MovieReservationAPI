using AutoMapper;
using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace ScheduleReservationAPI.Services
{
    public class SchedulesService(IScheduleRepository repository, IMapper mapper) : ISchedulesService
    {
        private readonly IScheduleRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task Create(ScheduleDTO newSchedule)
        {
            Schedule schedule = _mapper.Map<Schedule>(newSchedule);
            await _repository.Create(schedule);
        }

        public async Task Delete(int id)
        {
            Schedule? schedule =await _repository.Get(id);
            if(schedule is not null) await _repository.Delete(schedule);
        }

        public async Task<ICollection<ScheduleDTO>> Get()
        {
            return _mapper.Map<ICollection<ScheduleDTO>>(await _repository.Get());
        }

        public async Task<ScheduleDTO?> Get(int id)
        {
            Schedule? schedule = await _repository.Get(id);
            if (schedule is null) return null;
            return _mapper.Map<ScheduleDTO>(schedule);
        }

        public async Task Update(int id, ScheduleDTO updatedSchedule)
        {
            Schedule? schedule = await _repository.Get(id);
            if (schedule is null) return;
            _mapper.Map(updatedSchedule, schedule);
            await _repository.Save();
        }
    }
}
