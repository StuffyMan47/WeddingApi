using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Application.Constants;
using Application.Enums;
using Application.Interfaces.Settings;
using Application.Interfaces.TokenService;
using Application.Interfaces.TokenService.Models;
using Application.UseCase.User.GenerateToken.Models;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentication.JwtTokens;

public class JwtTokenService(IStorewebSettings settings) : IJwtTokenService
{
    public ValidateTokenResponse ValidateAccessToken(string accessToken, bool isValidateWithExpiry = true)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(accessToken, new()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = isValidateWithExpiry,
                ClockSkew = TimeSpan.Zero
            }, out var validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = Guid.Parse(jwtToken.Claims.First(x => x.Type == TokenClaimKeys.UserId).Value);
            int ownerId = int.Parse(jwtToken.Claims.First(x => x.Type == TokenClaimKeys.Owner).Value);
            var systemRole = Enum.Parse<SystemRole>(jwtToken.Claims.First(x => x.Type == TokenClaimKeys.SystemRole).Value);
            string login = jwtToken.Claims.First(x => x.Type == TokenClaimKeys.Login).Value;

            bool isGenerationSuccessful = userId != Guid.Empty &&
                ownerId != 0 &&
                systemRole != SystemRole.Couple &&
                login != "anonymous";

            return new()
            {
                IsSuccesss = isGenerationSuccessful,
                UserId = userId,
                OwnerId = ownerId,
                SystemRole = systemRole,
                Login = login,
            };
        }
        catch
        {
            return new()
            {
                IsSuccesss = false,
                UserId = Guid.Empty,
                OwnerId = 0,
                SystemRole = SystemRole.Couple,
                Login = "anonymous",
            };
        }
    }

    public string GenerateAcceesToken(GenerateTokenRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new(new[]
            {
                new Claim(TokenClaimKeys.UserId, request.UserId.ToString()),
                new Claim(TokenClaimKeys.SystemRole, Enum.GetName(request.SystemRole) ?? string.Empty),
                new Claim(TokenClaimKeys.Login, request.Login),
            }),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(settings.AuthSettings.TokenLifetimeMinutes)),
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public string GenerateRefreshToken()
    {
        byte[] randomNumber = new byte[64];
        using var randomNumberGenerator = RandomNumberGenerator.Create();
        randomNumberGenerator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}