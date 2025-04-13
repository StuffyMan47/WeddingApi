using Application.Models;
using Application.UserContext.Models;

namespace Application.UserContext;

public interface IUserContextProvider
{
    UserContextModel GetUserContext(SystemRequestData? system = null);
}