using Application.Interfaces;
using Application.UseCase.User.Login.Models;

namespace Application.UseCase.User.Login.Interfaces;

public interface ILoginStorage : IScopedService
{
    Task<UserModel?> GetUser(string login);
}