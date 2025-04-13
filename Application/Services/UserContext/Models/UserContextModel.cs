using Application.Enums;

namespace Application.UserContext.Models;

public class UserContextModel
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Login { get; init; } = "Anonymous";
    public SystemRole SystemRole { get; init; } = SystemRole.Couple;
}