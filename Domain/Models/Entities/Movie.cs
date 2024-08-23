using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Duration { get; set; }
        public DateOnly? ReleaseDate { get; set; }
        public ICollection<Schedule>? Schedules { get; set; }
    }
}
