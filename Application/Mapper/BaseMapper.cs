using AutoMapper;
using Domain.Interfaces.IMapper;

namespace Application.Mapper
{
    public class BaseMapper<TSource, TDestination>(IMapper mapper) : IBaseMapper<TSource, TDestination>
    {
        private readonly IMapper _mapper=mapper;
        public ICollection<TDestination> MapList(ICollection<TSource> source)
        {
            return _mapper.Map<ICollection<TDestination>>(source);
        }

        public TDestination MapModel(TSource source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
