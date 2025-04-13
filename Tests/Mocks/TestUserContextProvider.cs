using Application.Models;
using Application.UserContext;
using Application.UserContext.Models;

namespace Tests.Mocks;

public class TestUserContextProvider(UserContextModel user) : IUserContextProvider
{
    public UserContextModel GetUserContext(SystemRequestData? system = null)
    {
        return user;
    }
}