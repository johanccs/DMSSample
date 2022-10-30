namespace Pinewood.DMSSample.Business.Repositories
{
    public interface IQueryRepo<T>
    {
        Task<T?> GetByName(string name);
    }
}
