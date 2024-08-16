namespace MovieReservationAPI.Models.Entities
{
    public class Seat
    {
        public int Id { get; set; }
        public required int TheaterId { get; set; }
        public required Theater Theater { get; set; }
        public ICollection<Ticket> Tickets { get; } = [];
    }
}
