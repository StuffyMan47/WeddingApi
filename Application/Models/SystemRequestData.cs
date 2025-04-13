namespace Application.Models;

public record SystemRequestData(Guid UserId = default, int TenantId = 0, int? OwnerId = null);
