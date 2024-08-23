using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Data;
using Domain.Models.Entities;


namespace Infrastructure.Repositories
{
    public class TicketRepository(ApplicationDbContext dbContext) : BaseRepository<Ticket>(dbContext), ITicketRepository
    {
    }
}
