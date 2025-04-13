using Application.Extensions.ActionResult;
using Application.Interfaces.Settings;
using Application.Interfaces.TokenService;
using Application.UseCase.User.GenerateToken.Interfaces;
using Application.UseCase.User.GenerateToken.Models;

namespace Application.UseCase.User.GenerateToken;

public class GenerateTokenUseCase(IJwtTokenService service, IStorewebSettings settings, IGenerateTokenStorage storage)
{
    public async Task<Result<GenerateTokenResponse>> GenerateToken(GenerateTokenRequest request)
    {
        string accessToken = service.GenerateAcceesToken(request);
        string refreshToken = service.GenerateRefreshToken();
        int expirationInMinutes = int.Parse(settings.AuthSettings.RefreshTokenLifetimeMinutes);

        var result = new GenerateTokenResponse
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshExpirationDate = DateTimeOffset.UtcNow.AddMinutes(expirationInMinutes)
        };

        await storage.SaveUserRefreshToken(new()
        {
            RefreshToken = result.RefreshToken,
            TokenExpirationDate = result.RefreshExpirationDate,
            MaxSessionsPerUser = settings.AuthSettings.MaxSessionsPerUser,
            UserId = request.UserId
        });

        return Result<GenerateTokenResponse>.Success(result);
    }
}