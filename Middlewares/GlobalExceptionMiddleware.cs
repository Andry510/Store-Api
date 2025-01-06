using System.Net;
using store.Messages;
using store.Models;

namespace store.Middlewares;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public GlobalExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            BaseResponseException response = HandleExceptionAsync(error);

            context.Request.ContentType = "application/json";
            context.Response.StatusCode = response.StatusCode;

            await context.Response.WriteAsJsonAsync<BaseResponseException>(response);
        }
    }

    private BaseResponseException HandleExceptionAsync(Exception error)
    {
        var statusCode = HttpStatusCode.InternalServerError;
        string message = error.Message;

        switch (error)
        {
            case ArgumentNullException:
                statusCode = HttpStatusCode.BadRequest;
                if (string.IsNullOrEmpty(message))
                    message = MessagesClass.ErrorBadRequest();
                break;

            case UnauthorizedAccessException:
                statusCode = HttpStatusCode.Unauthorized;
                if (string.IsNullOrEmpty(message))
                    message = MessagesClass.ErrorUnauthorized();
                break;

            case InvalidCastException:
                statusCode = HttpStatusCode.Conflict;
                if (string.IsNullOrEmpty(message))
                    message = MessagesClass.ErrorConflict();
                break;
            case KeyNotFoundException:
                statusCode = HttpStatusCode.NotFound;
                if (string.IsNullOrEmpty(message))
                    message = MessagesClass.ErrorNotFound();
                break;
            default:
                if (string.IsNullOrEmpty(message))
                    message = MessagesClass.ErrorInternalServer();
                break;
        }


        return new BaseResponseException
        {
            StatusCode = (int)statusCode,
            Message = message,
            Timestamp = new DateTime(),
        };
    }
}
