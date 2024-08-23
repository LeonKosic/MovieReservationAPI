using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MovieReservationAPI.Data
{
    public class ApplicationDbContext: IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
