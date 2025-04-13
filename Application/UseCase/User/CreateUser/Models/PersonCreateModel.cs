using Application.Enums;

namespace Application.UseCase.User.CreateUser.Models;

public class PersonCreateModel
{
    public required string Name { get; init; }
    public required string? Surname { get; init; }
    public required string? FatherName { get; init; }
    public required Gender? Gender { get; init; }
    public required DateTimeOffset? BirthDate { get; init; }
}