using Microsoft.EntityFrameworkCore;
using MovieReservationAPI.Data;
using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class TheatersService(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _context = dbContext;

        public async Task<ICollection<Theater>> Get() =>
            await _context.Theaters.ToListAsync();

        public async Task<Theater?> Get(int id) =>
            await _context.Theaters.FindAsync(id);

        public async Task Create(Theater newTheater)
        {
            await _context.Theaters.AddAsync(newTheater);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Theater updatedTheater)
        {
            Theater? Theater = await _context.Theaters.FindAsync(id);
            if (Theater is null) return;
            Theater.Name = updatedTheater.Name;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Theater? Theater = await _context.Theaters.FindAsync(id);
            if (Theater is null)
                return;
            _context.Theaters.Remove(Theater);
            await _context.SaveChangesAsync();
        }
    }
}
