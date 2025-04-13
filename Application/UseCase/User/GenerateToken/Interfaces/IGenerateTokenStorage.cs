using Application.Interfaces;
using Application.UseCase.User.GenerateToken.Models;

namespace Application.UseCase.User.GenerateToken.Interfaces;

public interface IGenerateTokenStorage : IScopedService
{
    Task SaveUserRefreshToken(SaveUserTokenRequest request);
}