namespace Application.UseCase.Tenants.GetTenant.Models;

public record struct TenantModel(long Id, string Name, int? AgentId);
