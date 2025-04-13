using Application.Interfaces;

namespace Application.UseCase.Place.DeletePlace.Interfaces;

public interface IDeletePlaceStorage : IScopedService
{
    Task DeletePlaceAsync(long placeId);
}