using Domain.Interfaces.IRepositories;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models.Entities;


namespace Infrastructure.Repositories
{
    public class TicketRepository(ApplicationDbContext dbContext) : BaseRepository<Ticket>(dbContext), ITicketRepository
    {
    }
}
