using Application.Enums;

namespace Application.UseCase.User.RefreshToken.Models;

public class UserModel
{
    public required Guid UserId { get; init; }
    public required SystemRole SystemRole { get; init; }
    public required string Login { get; init; }
    public required string? RefreshTokenFromDb { get; init; }
    public required DateTimeOffset? RefreshTokenExpires { get; init; }
}
