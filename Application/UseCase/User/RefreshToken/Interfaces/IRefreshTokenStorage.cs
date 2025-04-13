using Application.Interfaces;
using Application.UseCase.User.RefreshToken.Models;

namespace Application.UseCase.User.RefreshToken.Interfaces;

public interface IRefreshTokenStorage : IScopedService
{
    Task<UserModel?> GetUser(Guid userId, string refreshToken);
}