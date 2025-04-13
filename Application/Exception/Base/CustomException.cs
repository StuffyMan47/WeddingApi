using System.Net;

namespace Application.Exception.Base;

public class CustomException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : IOException(message)
{
    public HttpStatusCode StatusCode { get; } = statusCode;
}