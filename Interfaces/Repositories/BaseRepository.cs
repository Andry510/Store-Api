namespace store.Interfaces;

public interface IBaseRepository<T>
{
    Task<T> Save();
    Task<T> FindOneById();
}
