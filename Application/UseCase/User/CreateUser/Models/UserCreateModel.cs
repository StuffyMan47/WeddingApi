using Application.Enums;

namespace Application.UseCase.User.CreateUser.Models;

public class UserCreateModel
{
    public required string Login { get; init; }
    public required string PasswordHash { get; init; }
    public required SystemRole SystemRole { get; init; }
    public required string PasswordSalt { get; init; }
    public required List<UserClaimCreateModel> UserClaims { get; init; }
}

public class UserClaimCreateModel
{
    public required string Claim { get; init; }
}