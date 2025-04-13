using Application.Interfaces;
using Application.UseCase.Tenants.GetTenant.Models;

namespace Application.UseCase.Tenants.GetTenant.Interfaces;

public interface IGetTenantsStorage : IScopedService
{
    Task<TenantModel?> GetTenantById(int id);
    Task<TenantModel?> GetTenantByName(string name);
    Task<TenantModel?> GetTenantByInn(string inn, string kpp);
    Task<List<TenantModel>> GetTenants();
}