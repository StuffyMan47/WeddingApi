using Application.Extensions.ActionResult;
using Application.UseCase.Place.AddPlace.Interfaces;
using Application.UseCase.Place.AddPlace.Models;

namespace Application.UseCase.Place.AddPlace;

public class AddPlaceUseCase(IAddPlaceStorage storage)
{
    public async Task<Result> AddPlace(AddPlaceRequest request)
    {
        await storage.CreatePlace(request);
        
        return Result.Success();
    }
}
