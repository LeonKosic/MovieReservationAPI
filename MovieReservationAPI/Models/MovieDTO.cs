namespace MovieReservationAPI.Models
{
    public class MovieDTO
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public string? Duration { get; set; }
        public DateOnly? ReleaseDate { get; set; }
    }
}
