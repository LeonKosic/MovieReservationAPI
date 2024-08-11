using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieReservationAPI.Models.Entities
{
    public class Ticket
    {
        public int Id { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int? ScheduleId { get; set; }
        public Schedule? Schedule { get; set; } 
        public int? SeatId {get; set; }
        public  Seat? Seat { get; set; }

        public IdentityUser? User { get; set; }
        public string? IdentityUserId { get; set; } 
        
    }
}
