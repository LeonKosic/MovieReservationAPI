using AutoMapper;
using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class TheatersService(ITheaterRepository repository, IMapper mapper) : ITheatersService
    {
        private readonly ITheaterRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        
        public async Task Create(TheaterDTO newTheater)
        {
            Theater  theater= _mapper.Map<Theater>(newTheater);
            await _repository.Create(theater);
        }

        public async Task Delete(int id)
        {
            var theater = await _repository.Get(id);
            if(theater!=null) await _repository.Delete(theater);
        }

        public async Task<ICollection<TheaterDTO>> Get()
        {
              return _mapper.Map<ICollection<TheaterDTO> >(await _repository.Get());
        }

        public async Task<TheaterDTO?> Get(int id)
        {
            return _mapper.Map<TheaterDTO>(await _repository.Get(id));
        }


        public async Task Update(int id, TheaterDTO updatedTheater)
        {
            Theater? theater = await _repository.Get(id);
            if (theater == null) return;
            _mapper.Map(updatedTheater,theater);
            await _repository.Save();
        }
    }
}
