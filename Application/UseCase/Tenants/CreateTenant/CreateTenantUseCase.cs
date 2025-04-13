using Application.Extensions.ActionResult;
using Application.UseCase.Tenants.CreateTenant.Interfaces;
using Application.UseCase.Tenants.CreateTenant.Models;

namespace Application.UseCase.Tenants.CreateTenant;

public class CreateTenantUseCase(ICreateTenantStorage storage)
{
    public async Task<Result<int>> CreateTenant(CreateTenantRequest request)
    {
        var result = await storage.CreateTenant(request);

        return Result<int>.Success(result);
    }
}