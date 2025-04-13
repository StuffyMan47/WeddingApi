using Application.Extensions.ActionResult;
using Application.UseCase.Place.GetPlace.Interfaces;
using Application.UseCase.Place.GetPlace.Models;

namespace Application.UseCase.Place.GetPlace;

public class GetPlaceUseCase(IGetPlaceStorage storage)
{
    public async Task<Result<GetPlaceResponse>> GetPlaceById(long placeId)
    {
        var placeInfo = await storage.GetPlace(placeId);

        if (placeInfo == null)
        {
            return Result.Invalid().WithMessage("Площадка не найдена").As<GetPlaceResponse>();
        }

        return Result<GetPlaceResponse>.Success(placeInfo);
    }
}
