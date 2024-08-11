using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class TicketsService(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _context = dbContext;

        public async Task<ICollection<Ticket>> Get() =>
            await _context.Tickets.ToListAsync();

        public async Task<Ticket?> Get(int id) =>
            await _context.Tickets.FindAsync(id);

        public async Task Create(Ticket newTicket)
        {
            await _context.Tickets.AddAsync(newTicket);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Ticket updatedTicket)
        {
            Ticket? Ticket = await _context.Tickets.FindAsync(id);
            if (Ticket is null) return;
            Ticket.Price = updatedTicket.Price;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Ticket? Ticket = await _context.Tickets.FindAsync(id);
            if (Ticket is null)
                return;
            _context.Tickets.Remove(Ticket);
            await _context.SaveChangesAsync();
        }
    }
}
