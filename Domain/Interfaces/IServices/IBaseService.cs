using MovieReservationAPI.Models.Entities;
using MovieReservationAPI.Models;

namespace MovieReservationAPI.Interfaces.IServices
{
    public interface IBaseService<T,TDO> where T : class where TDO : struct
    {
        public Task<ICollection<TDO>> Get();

        public Task<TDO?> Get(int id);

        public Task Create(T newTheater);
        public Task Update(int id, T updatedTheater);
        public Task Delete(int id);
    }
}
