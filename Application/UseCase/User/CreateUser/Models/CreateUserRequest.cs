using Application.Enums;

namespace Application.UseCase.User.CreateUser.Models;

public class CreateUserRequest
{
    public string Password { get; init; } = null!;
    public string Login { get; init; } = null!;
    public string Name { get; init; } = null!;
    public string Surname { get; init; } = null!;
    public string? FatherName { get; init; }
    public Gender? Gender { get; init; }
    public DateTimeOffset? BirthDate { get; init; }
}