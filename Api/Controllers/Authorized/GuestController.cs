using Application.UseCase.Guest.AddGuest;
using Application.UseCase.Guest.AddGuest.Models;
using Application.UseCase.Guest.AddGuestsList;
using Application.UseCase.Guest.AddGuestsList.Models;
using Application.UseCase.Guest.DeleteGuest;
using Application.UseCase.Guest.GetGuest;
using Application.UseCase.Guest.GetGuest.Models;
using Application.UseCase.Guest.GetGuestsList;
using Application.UseCase.Guest.GetGuestsList.Models;
using Bar.Controllers.Base;
using Bar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Wedding.Controllers.Authorized;

public class GuestController : BaseAuthController
{
    /// <summary>
    /// Получить список гостей
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    [ProducesResponseType(typeof(BaseApiResponseModel<GetGuestsListResponse>), 200)]
    public async Task<IActionResult> GetGuestsList([FromServices] GetGuestsListUseCase useCase)
    {
        var result = await useCase.GetGuestsList();
        return FromResult(result);
    }
    
    /// <summary>
    /// Получить информацию о конкретном госте
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(typeof(BaseApiResponseModel<GetGuestResponse>), 200)]
    public async Task<IActionResult> GetGuest([FromServices] GetGuestUseCase useCase)
    {
        var result = await useCase.GetGuest();
        return FromResult(result);
    }

    /// <summary>
    /// Создать гостя
    /// </summary>
    /// <returns></returns>
    [HttpPost()]
    [ProducesResponseType(typeof(ApiResponseModel), 200)]
    public async Task<IActionResult> AddGuest([FromServices] AddGuestUseCase useCase, AddGuestRequest request)
    {
        var result = await useCase.AddGuest(request);
        return FromResult(result);
    }

    /// <summary>
    /// Создать список гостей
    /// </summary>
    /// <returns></returns>
    [HttpPost("list")]
    [ProducesResponseType(typeof(ApiResponseModel), 200)]
    public async Task<IActionResult> AddGuestList([FromServices] AddGuestsListUseCase useCase, List<AddGuestsListRequest> requests)
    {
        var result = await useCase.AddGuestsList(requests);
        return FromResult(result);
    }

    /// <summary>
    /// Удалить гостя
    /// </summary>
    /// <returns></returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(typeof(ApiResponseModel), 200)]
    public async Task<IActionResult> DeleteGuest([FromServices] DeleteGuestUseCase useCase, Guid id)
    {
        var result = await useCase.DeleteGuest(id);
        return FromResult(result);
    }
}

