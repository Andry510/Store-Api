namespace store.Interfaces;


public interface IBaseResponseMessage
{
    string Message { get; set; }
}

public interface IBaseResponse<T>
{
    string Message { get; set; }
    T? Data { get; set; }
}

public interface IBaseResponseException
{
    int StatusCode { get; set; }
    string Message { get; set; }
    DateTime Timestamp { get; set; }

}

public interface IBaseResponseLogin
{
    string Message { get; set; }
    string Token { get; set; }
}