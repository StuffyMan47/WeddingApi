namespace Application.Extensions.ActionResult;

public enum ResultType
{
    Success = 0,
    Unauthorized = 100,
    PermissionDenied = 200,
    NotFound = 300,
    Invalid = 400
}