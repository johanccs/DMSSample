namespace Pinewood.DMSSample.Business.Repositories
{
    public interface ICommandRepo<T>
    {
        Task Add(T entity);
    }
}
