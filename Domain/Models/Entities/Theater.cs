namespace Domain.Models.Entities
{
    public class Theater
    {
        public int Id { get; set; }

        public required string Name { get; set; }
        public ICollection<Seat> Seats { get; } = [];
        public ICollection<Schedule> Schedules { get; } = [];
    }
}
