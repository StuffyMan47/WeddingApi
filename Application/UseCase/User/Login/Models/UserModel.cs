using Application.Enums;

namespace Application.UseCase.User.Login.Models;

public class UserModel
{
    public required Guid UserId { get; init; }
    public required SystemRole SystemRole { get; init; }
    public required string Login { get; init; }
    public required string PasswordHash { get; init; }
    public required string PasswordSalt { get; init; }
}