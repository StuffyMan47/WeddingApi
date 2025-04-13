namespace Application.Interfaces.Settings.Models;

public class AuthSettings
{
    public required string TokenLifetimeMinutes { get; init; }
    public required string RefreshTokenLifetimeMinutes { get; init; }
    public required int MaxSessionsPerUser { get; init; } = 20; // надо перенести в appsettings.json
}