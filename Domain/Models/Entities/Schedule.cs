namespace Domain.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public required DateOnly Start { get; set; }
        public required DateOnly End { get; set; }
        public required TimeOnly Time { get; set; }       
        public required int MovieId {get; set; }
        public required Movie Movie { get; set; }
        public required int TheaterId { get; set; }
        public required Theater Theater { get; set; }
        public  ICollection<Ticket> Tickets { get; } = [];
    }
}
