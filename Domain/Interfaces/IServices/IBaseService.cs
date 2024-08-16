using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;

namespace MovieReservationAPI.Interfaces.IServices
{
    public interface IBaseService<T>
    {
        public Task<ICollection<T>> Get();

        public Task<T?> Get(int id);

        public Task Create(T newTheater);
        public Task Update(int id, T updatedTheater);
        public Task Delete(int id);
    }
}
