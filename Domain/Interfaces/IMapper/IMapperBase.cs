namespace Domain.Interfaces.IMapper
{
    public interface IMapperBase<TSource,TDestination>
    {
        TDestination MapModel(TSource source);
        ICollection<TDestination> MapList(ICollection<TSource> source); 
    }
}
