namespace DotAgroAPI.Data.Repository
{
    public interface IRepository<T>
    {
        Task<List<T>> Get();
        Task<T> Post(T entity);
        Task<T?> Put(int id, T entity);
        Task<T?> Delete(int id);
    }
}
