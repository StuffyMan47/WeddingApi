using Application.Interfaces.TokenService.Models;
using Application.UseCase.User.GenerateToken.Models;

namespace Application.Interfaces.TokenService;

public interface IJwtTokenService : IScopedService
{
    ValidateTokenResponse ValidateAccessToken(string accessToken, bool isValidateWithExpiry = true);
    string GenerateAcceesToken(GenerateTokenRequest request);
    string GenerateRefreshToken();
}