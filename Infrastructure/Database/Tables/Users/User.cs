using Application.Enums;
using Infrastructure.Database.Entities;

namespace Infrastructure.Database.Tables.Users;

public class User : BaseEntity<Guid>
{
    public required string Login { get; init; }
    public required string PasswordHash { get; init; }
    public required string PasswordSalt { get; init; }
    
    public SystemRole SystemRole { get; init; }
    
    public DateTimeOffset CreatedAt { get; init; }
    public DateTimeOffset? BannedAt { get; init; }
    
    public List<UserToken> UserTokens { get; init; } = [];
    
    public User? InvitedBy { get; init; }
}