namespace Application.UseCase.User.Login.Models;

public record struct LoginResponse(string AccessToken, string RefreshToken);
