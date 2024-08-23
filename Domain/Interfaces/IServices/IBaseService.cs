using Domain.Results;

namespace Domain.Interfaces.IServices
{
    public interface IBaseService<T,DTO> where T : class where DTO : struct
    {
        public Task<Result<ICollection<DTO>>> Get();

        public Task<Result<DTO>> Get(int id);

        public Task<Result> Create(DTO newTheater);
        public Task<Result> Update(int id, DTO updatedTheater);
        public Task<Result> Delete(int id);
    }
}
