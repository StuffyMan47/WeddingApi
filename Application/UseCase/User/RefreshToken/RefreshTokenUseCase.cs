using Application.Errors;
using Application.Extensions.ActionResult;
using Application.Interfaces.TokenService;
using Application.UseCase.User.GenerateToken;
using Application.UseCase.User.RefreshToken.Interfaces;
using Application.UseCase.User.RefreshToken.Models;

namespace Application.UseCase.User.RefreshToken;

public class RefreshTokenUseCase(IRefreshTokenStorage storage, GenerateTokenUseCase tokenGenerator, IJwtTokenService tokenService)
{
    public async Task<Result<RefreshTokenResponse>> RefreshToken(RefreshTokenRequest request)
    {
        var tokenValidation = tokenService.ValidateAccessToken(request.AccessToken, false);

        if (!tokenValidation.IsSuccesss)
            return ErrorProvider.Auth.InvalidAccessToken.As<RefreshTokenResponse>();

        var user = await storage.GetUser(tokenValidation.UserId, request.RefreshToken);
        if (user == null)
            return ErrorProvider.Users.NotFound(tokenValidation.UserId).As<RefreshTokenResponse>();

        if (user.RefreshTokenFromDb == null)
            return ErrorProvider.Auth.RefreshTokenWasNotIssued.As<RefreshTokenResponse>();

        bool isRefreshTokenExpired = user.RefreshTokenExpires == null || user.RefreshTokenExpires.Value.ToUniversalTime() < DateTimeOffset.UtcNow;
        if (isRefreshTokenExpired)
            return ErrorProvider.Auth.InvalidRefreshToken.As<RefreshTokenResponse>();

        var token = await tokenGenerator.GenerateToken(new()
        {
            UserId = user.UserId,
            SystemRole = user.SystemRole,
            Login = user.Login,
        });

        return token.IsFailure
            ? token.As<RefreshTokenResponse>()
            : Result<RefreshTokenResponse>.Success(new(token.Value.AccessToken, token.Value.RefreshToken));
    }
}
