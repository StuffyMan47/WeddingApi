using Application.Interfaces;
using Application.UseCase.Place.AddPlace.Models;

namespace Application.UseCase.Place.AddPlace.Interfaces;

public interface IAddPlaceStorage : IScopedService
{
    Task CreatePlace(AddPlaceRequest request);
}