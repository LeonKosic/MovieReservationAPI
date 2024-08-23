using Domain.Models.Entities;
using Domain.Models;
using Domain.Results;

namespace Domain.Interfaces.IServices
{
    public interface ITicketsService:IBaseService<Ticket,TicketDTO>
    {
        public Task<Result<TicketDTO>> Buy(int id, string userId);
    
    }
}
