using Application.Interfaces;
using Application.UseCase.Tenants.CreateTenant.Models;

namespace Application.UseCase.Tenants.CreateTenant.Interfaces;

public interface ICreateTenantStorage : IScopedService
{
    Task<long> CreateTenant(CreateTenantRequest request);
}