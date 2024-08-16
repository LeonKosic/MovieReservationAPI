using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Interfaces.IServices;
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class TicketsService(ITicketRepository repository) : ITicketsService
    {
        private ITicketRepository _repository = repository;
        public Task Create(Ticket newTheater)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<TicketDTO>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TicketDTO?> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(int id, Ticket updatedTheater)
        {
            throw new NotImplementedException();
        }
        public Task<TicketDTO> Buy(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
