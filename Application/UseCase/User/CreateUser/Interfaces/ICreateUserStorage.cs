using Application.Interfaces;
using Application.UseCase.User.CreateUser.Models;

namespace Application.UseCase.User.CreateUser.Interfaces;

public interface ICreateUserStorage : IScopedService
{
    Task<bool> IsLoginAlreadyTaken(string login);
    Task<Guid> SaveUser(UserCreateModel user);
}