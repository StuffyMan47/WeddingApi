using Application.UseCase.Tenants.CreateTenant.Interfaces;
using Application.UseCase.Tenants.CreateTenant.Models;
using Infrastructure.Database.DbContext;

namespace Infrastructure.Database.Storages.Tenant;

public class CreateTenantStorage(AppDbContext dbContext) : ICreateTenantStorage
{
    public async Task<long> CreateTenant(CreateTenantRequest request)
    {
        var newOwner = new Tables.Owner.Owner
        {
            OwnerName = request.Name,
        };
        dbContext.Owners.Add(newOwner);

        await dbContext.SaveChangesAsync();

        return newOwner.Id;
    }
}
