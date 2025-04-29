using Application.UseCase.Guest.GetGuestsList.Models;
using Application.UseCase.Guest.GetGuestsList;
using Microsoft.AspNetCore.Mvc;
using WeddingApi.Controllers.Base;
using WeddingApi.Models;
using Application.UseCase.Tenants.GetTenant;
using Application.UseCase.Tenants.CreateTenant;
using Application.UseCase.Tenants.GetTenant.Models;
using Application.UseCase.Tenants.CreateTenant.Models;

namespace Wedding.Controllers.Authorized;

public class OwnerController : BaseAuthController
{
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(BaseApiResponseModel<TenantModel>), 200)]
    public async Task<IActionResult> GetOwner([FromServices] GetTenantsUseCase useCase, int id)
    {
        var result = await useCase.GetTenantById(id);
        return FromResult(result);
    }


    [HttpPost("by-name")]
    [ProducesResponseType(typeof(BaseApiResponseModel<TenantModel>), 200)]
    public async Task<IActionResult> GetOwner([FromServices] GetTenantsUseCase useCase, string name)
    {
        var result = await useCase.GetTenantByName(name);
        return FromResult(result);
    }

    [HttpGet()]
    [ProducesResponseType(typeof(BaseApiResponseModel<List<TenantModel>>), 200)]
    public async Task<IActionResult> GetOwner([FromServices] GetTenantsUseCase useCase)
    {
        var result = await useCase.GetTenantsList();
        return FromResult(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(BaseApiResponseModel<GetGuestsListResponse>), 200)]
    public async Task<IActionResult> GetOwner([FromServices] CreateTenantUseCase useCase, CreateTenantRequest request)
    {
        var result = await useCase.CreateTenant(request);
        return FromResult(result);
    }
}
