using Application.Extensions.ActionResult;

namespace Infrastructure.Database.Initializers.Seeders;

public partial class DataSeeder
{
    public async Task<Result<int>> CreateTenantByName(string tenantName)
    {
        return await createTenant.CreateTenant(new(Name: tenantName));
    }
    
}