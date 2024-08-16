using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Services
{
    public class MoviesService(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _context = dbContext;

        public async Task<ICollection<Movie>> Get() =>
            await _context.Movies.ToListAsync();

        public async Task<Movie?> Get(int id) =>
            await _context.Movies.FindAsync(id);

        public async Task Create(Movie newMovie)
        {
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, Movie updatedMovie)
        {
            Movie? movie = await _context.Movies.FindAsync(id);
            if (movie is null) return; //todo
            movie.Name = updatedMovie.Name;
            movie.Description = updatedMovie.Description;
            movie.Duration = updatedMovie.Duration;
            movie.ReleaseDate = updatedMovie.ReleaseDate;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Movie? movie = await _context.Movies.FindAsync(id);
            if (movie is null)
                return; //todo
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}
