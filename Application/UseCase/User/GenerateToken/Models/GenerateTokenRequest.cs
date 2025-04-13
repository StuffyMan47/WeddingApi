using Application.Enums;

namespace Application.UseCase.User.GenerateToken.Models;

public class GenerateTokenRequest
{
    public required Guid UserId { get; init; }
    public required SystemRole SystemRole { get; init; }
    public required string Login { get; init; }
}