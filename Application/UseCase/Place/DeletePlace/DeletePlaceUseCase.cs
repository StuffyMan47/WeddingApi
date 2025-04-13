using Application.Extensions.ActionResult;
using Application.UseCase.Place.DeletePlace.Interfaces;

namespace Application.UseCase.Place.DeletePlace;

public class DeletePlaceUseCase(IDeletePlaceStorage storage)
{
    public async Task<Result> DeletePlace(long placeId)
    {
        await storage.DeletePlaceAsync(placeId);
        
        return Result.Success();
    }
}
