using Application.Constants;
using Application.Models;
using Application.UserContext;
using Application.UserContext.Models;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Services;

public class UserContextProvider(IHttpContextAccessor httpContextAccessor) : IUserContextProvider
{
    public UserContextModel GetUserContext(SystemRequestData? system = null)
    {
        var user = GetUser(httpContextAccessor.HttpContext);
        if (user.Id != Guid.Empty)
            return user;

        if (system != null)
        {
            return new()
            {
                Id = system.UserId,
                Login = SystemConstants.SystemLogin,
            };
        }

        return new();
    }

    private static UserContextModel GetUser(HttpContext? context)
    {
        if (context == null)
            return new();

        var user = context.User;
        try
        {
            var userId = Guid.Parse(user.Claims.First(x => x.Type == TokenClaimKeys.UserId).Value);
            string login = user.Claims.First(x => x.Type == TokenClaimKeys.Login).Value;

            return new()
            {
                Id = userId,
                Login = login,
            };
        }
        catch
        {
            return new();
        }
    }
}