using Application.UseCase.Tenants.GetTenant.Interfaces;
using Application.UseCase.Tenants.GetTenant.Models;

namespace Infrastructure.Database.Storages.Tenant;

public class GetTenantStorage : IGetTenantsStorage
{
    public Task<TenantModel?> GetTenantById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<TenantModel?> GetTenantByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<TenantModel>> GetTenants()
    {
        throw new NotImplementedException();
    }
}
