using Microsoft.AspNetCore.Identity;
using MovieReservationAPI.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationAPI.Models
{
    public class TicketDTO
    {
        public decimal Price { get; set; }
        public int ScheduleId { get; set; }
        public int SeatId { get; set; }
    }
}
