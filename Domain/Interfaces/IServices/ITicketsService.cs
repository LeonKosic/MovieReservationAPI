using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;

namespace MovieReservationAPI.Interfaces.IServices
{
    public interface ITicketsService:IBaseService<Ticket,TicketDTO>
    {
        public Task<TicketDTO> Buy(int id, string userId);
    
    }
}
