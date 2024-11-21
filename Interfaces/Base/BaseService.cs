namespace store.Interfaces;

public interface IBaseService<T>
{
    Task<T> Save();
    Task<T> FindOneById();

}
