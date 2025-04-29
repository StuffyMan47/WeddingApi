using Application.UseCase.Tenants.GetTenant.Interfaces;
using Application.UseCase.Tenants.GetTenant.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Tenant;

public class GetTenantStorage(AppDbContext dbContext) : IGetTenantsStorage
{
    public async Task<TenantModel?> GetTenantById(int id)
    {
        return await dbContext.Owners
            .Select(x=> new TenantModel(x.Id, x.OwnerName, null))
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TenantModel?> GetTenantByName(string name)
    {
        return await dbContext.Owners
            .Select(x => new TenantModel(x.Id, x.OwnerName, null))
            .FirstOrDefaultAsync(x => x.Name.Contains(name));
    }

    public async Task<List<TenantModel>> GetTenants()
    {
        return await dbContext.Owners
            .Select(x => new TenantModel(x.Id, x.OwnerName, null))
            .ToListAsync();
    }
}
