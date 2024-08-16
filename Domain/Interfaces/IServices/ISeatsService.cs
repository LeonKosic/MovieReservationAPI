using MovieReservationAPI.Models;

using MovieReservationAPI.Models.Entities;
namespace MovieReservationAPI.Interfaces.IServices
{
    public interface ISeatsService: IBaseService<Seat,SeatDTO>
    {
    }
}
