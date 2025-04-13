using Application.UseCase.Place.AddPlace;
using Application.UseCase.Place.AddPlace.Models;
using Application.UseCase.Place.GetPlace;
using Application.UseCase.Place.GetPlace.Models;
using Application.UseCase.Place.GetPlacesList;
using Application.UseCase.Place.GetPlacesList.Models;
using Application.UseCase.Place.UpdatePlace;
using Application.UseCase.Place.UpdatePlace.Models;
using Bar.Controllers.Base;
using Bar.Models;
using Microsoft.AspNetCore.Mvc;

namespace Wedding.Controllers.Authorized;

public class PlaceController : BaseAuthController
{
    /// <summary>
    /// Получить площадку
    /// </summary>
    /// <returns></returns>
    [HttpGet("{id:long}")]
    [ProducesResponseType(typeof(BaseApiResponseModel<GetPlaceResponse>), 200)]
    public async Task<IActionResult> GetPlaceById([FromServices] GetPlaceUseCase useCase, long id)
    {
        var result = await useCase.GetPlaceById(id);
        return FromResult(result);
    }

    /// <summary>
    /// Создать площадку
    /// </summary>
    /// <returns></returns>
    [HttpPost("create")]
    [ProducesResponseType(typeof(ApiResponseModel), 200)]
    public async Task<IActionResult> GetPlaceByGuestId([FromServices] AddPlaceUseCase useCase, AddPlaceRequest request)
    {
        var result = await useCase.AddPlace(request);
        return FromResult(result);
    }

    /// <summary>
    /// Получить список площадок
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    [ProducesResponseType(typeof(BaseApiResponseModel<List<GetPlacesListResponse>>), 200)]
    public async Task<IActionResult> GetPlaceList([FromServices] GetPlacesListUseCase useCase)
    {
        var result = await useCase.GetPlacesList();
        return FromResult(result);
    }

    /// <summary>
    /// Изменить площадку
    /// </summary>
    /// <returns></returns>
    [HttpPut()]
    [ProducesResponseType(typeof(ApiResponseModel), 200)]
    public async Task<IActionResult> UpdatePlace([FromServices] UpdatePlaceUseCase useCase, UpdatePlaceRequest request)
    {
        var result = await useCase.UpdatePlace(request);
        return FromResult(result);
    }
}
