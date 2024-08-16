namespace Domain.Interfaces.IMapper
{
    public interface IBaseMapper<TSource,TDestination>
    {
        TDestination MapModel(TSource source);
        ICollection<TDestination> MapList(ICollection<TSource> source); 
    }
}
