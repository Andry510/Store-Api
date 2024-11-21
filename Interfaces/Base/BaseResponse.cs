namespace store.Interfaces;

public interface IBaseResponse<T>
{
    string Message { get; set; }
    T?  Data { get; set; }
}
