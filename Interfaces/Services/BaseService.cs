namespace store.Interfaces;

public interface IBaseService<T>
{
    Task<T?> Create(T authentication);
}
