namespace Application.UseCase.User.RefreshToken.Models;

public record RefreshTokenResponse(string AccessToken, string RefreshToken);