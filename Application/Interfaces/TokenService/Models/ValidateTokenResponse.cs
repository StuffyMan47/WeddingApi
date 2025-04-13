using Application.Enums;

namespace Application.Interfaces.TokenService.Models;

public class ValidateTokenResponse
{
    public required bool IsSuccesss { get; init; }
    public required Guid UserId { get; init; }
    public required string Login { get; init; }
    public required long OwnerId { get; init; }
    public required SystemRole SystemRole { get; init; }
}