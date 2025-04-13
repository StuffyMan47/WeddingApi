using Application.Extensions.ActionResult;
using Application.UseCase.Place.UpdatePlace.Interfaces;
using Application.UseCase.Place.UpdatePlace.Models;

namespace Application.UseCase.Place.UpdatePlace;

public class UpdatePlaceUseCase(IUpdatePlaceStorage storage)
{
    public async Task<Result> UpdatePlace(UpdatePlaceRequest request)
    {
        await storage.UpdatePlace(request);
        
        return Result.Success();
    }
}
