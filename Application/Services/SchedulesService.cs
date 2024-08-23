using AutoMapper;
using Domain.Errors;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Results;

namespace Application.Services
{
    public class SchedulesService(IScheduleRepository repository, IMapper mapper) : ISchedulesService
    {
        private readonly IScheduleRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result> Create(ScheduleDTO newSchedule)
        {
            Schedule schedule = _mapper.Map<Schedule>(newSchedule);
            await _repository.Create(schedule);
            return Result.Success();
        }

        public async Task<Result> Delete(int id)
        {
            Schedule? schedule =await _repository.Get(id);
            if (schedule is null) return Result.Failure(Error.NotFound);
            await _repository.Delete(schedule);
            return Result.Success();
        }

        public async Task<Result<ICollection<ScheduleDTO>>> Get()
        {
            var schedules = await _repository.Get();
            if (schedules is null) return Result<ICollection<ScheduleDTO>>.Failure(Error.NotFound);
            var dtos = _mapper.Map<ICollection<ScheduleDTO>>(schedules);
            return Result<ICollection<ScheduleDTO>>.Success(dtos);

        }

        public async Task<Result<ScheduleDTO>> Get(int id)
        {
            Schedule? schedule = await _repository.Get(id);
            if (schedule is null) return Result<ScheduleDTO>.Failure(Error.NotFound);
            var dtos= _mapper.Map<ScheduleDTO>(schedule);
            return Result<ScheduleDTO>.Success(dtos);
        }

        public async Task<Result> Update(int id, ScheduleDTO updatedSchedule)
        {
            Schedule? schedule = await _repository.Get(id);
            if (schedule is null) return Result.Failure(Error.NotFound);
            _mapper.Map(updatedSchedule, schedule);
            await _repository.Save();
            return Result.Success();
        }
    }
}
