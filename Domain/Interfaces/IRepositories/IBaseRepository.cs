

namespace Domain.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<ICollection<T>> Get();
        Task<T?> Get(int id);
        Task<T> Create (T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
