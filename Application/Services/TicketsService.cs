using AutoMapper;
using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class TicketsService(ITicketRepository repository, IMapper mapper) : ITicketsService
    {
        private ITicketRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task Create(TicketDTO newTicket)
        {
            Ticket ticket = _mapper.Map<Ticket>(newTicket);
            await _repository.Create(ticket);
        }

        public async Task Delete(int id)
        {
            var ticket = await _repository.Get(id);
            if(ticket!=null) await _repository.Delete(ticket);
        }

        public async Task<ICollection<TicketDTO>> Get()
        {
            return _mapper.Map<ICollection<TicketDTO>>(await _repository.Get());
        }

        public async Task<TicketDTO?> Get(int id)
        {
            var ticket = await _repository.Get(id);
            return _mapper.Map<TicketDTO>(ticket);
        }

        public async Task Update(int id, TicketDTO updatedTicket)
        {
            var ticket = await _repository.Get(id);
            _mapper.Map(updatedTicket,ticket);
            await _repository.Save();
        }
        public async Task<TicketDTO> Buy(int id, string userId)
        {
            throw new NotImplementedException();//TODO
        }
    }
}
