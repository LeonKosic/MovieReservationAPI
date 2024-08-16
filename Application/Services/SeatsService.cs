﻿
using MovieReservationAPI.Models;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class SeatsService(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _context = dbContext;

        public async Task<ICollection<Seat>> Get() =>
            await _context.Seats.ToListAsync();

        public async Task<Seat?> Get(int id) =>
            await _context.Seats.FindAsync(id);

        public async Task Create(SeatDTO newSeat)
        {
            Theater? theater = await _context.Theaters.FindAsync(newSeat.TheaterId);
            if (theater is null) return;//todo
            Seat seat = new() { Theater=theater, TheaterId=newSeat.TheaterId};
            await _context.Seats.AddAsync(seat);
            await _context.SaveChangesAsync();
        }


        public async Task Delete(int id)
        {
            Seat? Seat = await _context.Seats.FindAsync(id);
            if (Seat is null)
                return; //todo
            _context.Seats.Remove(Seat);
            await _context.SaveChangesAsync();
        }
    }
}
