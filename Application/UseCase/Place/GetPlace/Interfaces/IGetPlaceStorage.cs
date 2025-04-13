using Application.Interfaces;
using Application.UseCase.Place.GetPlace.Models;

namespace Application.UseCase.Place.GetPlace.Interfaces;

public interface IGetPlaceStorage : IScopedService
{
    Task<GetPlaceResponse> GetPlace(long placeId);
}