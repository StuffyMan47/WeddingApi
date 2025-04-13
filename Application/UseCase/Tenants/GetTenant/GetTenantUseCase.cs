using Application.Errors;
using Application.Extensions.ActionResult;
using Application.UseCase.Tenants.GetTenant.Interfaces;
using Application.UseCase.Tenants.GetTenant.Models;

namespace Application.UseCase.Tenants.GetTenant;

public class GetTenantsUseCase(IGetTenantsStorage storage)
{
    public async Task<Result<TenantModel>> GetTenantById(int id)
    {
        var result = await storage.GetTenantById(id);

        return result == null
            ? ErrorProvider.Tenants.NotFound(id).As<TenantModel>()
            : Result<TenantModel>.Success((TenantModel)result);
    }

    public async Task<Result<TenantModel>> GetTenantByName(string name)
    {
        var result = await storage.GetTenantByName(name);
        return result == null
            ? Result<TenantModel>.Invalid().WithMessage($"Тенант с именем {name} не найден")
            : Result<TenantModel>.Success((TenantModel)result);
    }

    public async Task<Result<List<TenantModel>>> GetTenantsList()
    {
        var result = await storage.GetTenants();
        return Result<List<TenantModel>>.Success(result);
    }
}