using MovieReservationAPI.Models.Entities;

namespace MovieReservationAPI.Models
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public required DateOnly Start { get; set; }
        public required DateOnly End { get; set; }
        public required TimeOnly Time { get; set; }
        public required int MovieId { get; set; }
        public required int TheaterId { get; set; }

    }
}
