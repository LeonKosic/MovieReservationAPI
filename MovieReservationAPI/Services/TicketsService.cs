using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models;
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

        public async Task Create(TicketDTO newTicket)
        {
            Ticket ticket = new() { Price = newTicket.Price, ScheduleId = newTicket.ScheduleId, SeatId = newTicket.SeatId};
            Schedule? Schedule= await _context.Schedules.FindAsync(newTicket.ScheduleId);
            Seat? Seat = await _context.Seats.FindAsync(newTicket.SeatId); ;      
            if(Schedule is not null)
            {
                ticket.Schedule = Schedule;
            }
            if (Seat is not null)
            {
                ticket.Seat = Seat;
            }
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }
        public async Task Bought(int id, string userId)
        {
            Ticket? Ticket = await _context.Tickets.FindAsync(id);
            if (Ticket is null) return;//todo
            Ticket.IdentityUserId = userId;
            await _context.SaveChangesAsync();  
        }
        public async Task Update(int id, TicketDTO updatedTicket)
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
