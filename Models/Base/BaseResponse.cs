using store.Interfaces;

namespace store.Models;

public class BaseResponseMessage : IBaseResponseMessage
{
    public required string Message { get; set; }
}

public class BaseResponseException : IBaseResponseException
{
    public int StatusCode { get; set; }
    public required string Message { get; set; }

    public DateTime Timestamp { get; set; }
}

public class BaseResponse<T> : IBaseResponse<T>
{
    public required string Message { get; set; }
    public T? Data { get; set; }
}

public class BaseResponseLogin : IBaseResponseLogin
{
    public required string Message { get; set; }
    public required string Token { get; set; }
}