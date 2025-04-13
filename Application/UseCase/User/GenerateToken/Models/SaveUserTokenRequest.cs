namespace Application.UseCase.User.GenerateToken.Models;

public class SaveUserTokenRequest
{
    public required Guid UserId { get; init; }
    public required string RefreshToken { get; init; }
    public required DateTimeOffset TokenExpirationDate { get; init; }
    public required int MaxSessionsPerUser { get; init; }
}