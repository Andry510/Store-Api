namespace store.Interfaces;

public interface IBaseRepository<T>
{
    Task Save(T data);
    Task<T?> FindOneById(Guid id);
}
