using AutoMapper;
using Domain.Errors;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Domain.Models;
using Domain.Models.Entities;
using Domain.Results;

namespace Application.Services
{
    public class TicketsService(ITicketRepository repository, IMapper mapper) : ITicketsService
    {
        private ITicketRepository _repository = repository;
        private readonly IMapper _mapper = mapper;
        public async Task<Result> Create(TicketDTO newTicket)
        {
            Ticket ticket = _mapper.Map<Ticket>(newTicket);
            await _repository.Create(ticket);
            return Result.Success();
        }

        public async Task<Result> Delete(int id)
        {
            var ticket = await _repository.Get(id);
            if (ticket is null) return Result.Failure(Error.NotFound);
            await _repository.Delete(ticket);
            return Result.Success();
        }

        public async Task<Result<ICollection<TicketDTO>>> Get()
        {
            var tickets = await _repository.Get();
            if(tickets is null) return Result<ICollection<TicketDTO>>.Failure(Error.NotFound);
            var ticketsDTO=_mapper.Map<ICollection<TicketDTO>>(tickets);
            return Result<ICollection<TicketDTO>>.Success(ticketsDTO);  
        }

        public async Task<Result<TicketDTO>> Get(int id)
        {
            var ticket = await _repository.Get(id);
            if (ticket is null) return Result<TicketDTO>.Failure(Error.NotFound);
            var ticketDTO = _mapper.Map<TicketDTO>(ticket);
            return Result<TicketDTO>.Success(ticketDTO);
        }

        public async Task<Result> Update(int id, TicketDTO updatedTicket)
        {
            var ticket = await _repository.Get(id);
            if(ticket is null) return Result.Failure(Error.NotFound);
            _mapper.Map(updatedTicket,ticket);
            await _repository.Save();
            return Result.Success();
        }
        public async Task<Result<TicketDTO>> Buy(int id, string userId)
        {
            throw new NotImplementedException();//TODO
        }
    }
}
