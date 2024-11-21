using store.Interfaces;

namespace store.Models;

public class BaseResponse<T> : IBaseResponse<T>
{
    public required string Message { get; set; }
    public T? Data { get; set; }
}
