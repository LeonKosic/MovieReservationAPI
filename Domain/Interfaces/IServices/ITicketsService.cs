using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;

namespace MovieReservationAPI.Interfaces.IServices
{
    public interface ITicketsService
    {
        public Task Buy(int id, string userId);
    
    }
}
