namespace Application.UseCase.Tenants.GetTenant.Models;

public record struct TenantModel(int Id, string Name, int? AgentId);
