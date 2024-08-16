using MovieReservationAPI.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationAPI.Models
{
    public readonly record struct SeatDTO(int Id,int TheaterId);

    public readonly record struct TicketDTO(int Id,decimal Price, int ScheduleId, int SeatId);

    public readonly record struct ScheduleDTO(int Id,DateOnly Start, DateOnly End, TimeOnly Time, int MovieId, int TheaterId);

    public readonly record struct MovieDTO(int Id,string Name, string? Description, string? Duration, DateOnly? ReleaseDate);

    public readonly record struct TheaterDTO(int Id,string Name);
}
