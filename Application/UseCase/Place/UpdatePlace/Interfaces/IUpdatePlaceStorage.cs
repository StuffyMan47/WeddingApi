using Application.Interfaces;
using Application.UseCase.Place.UpdatePlace.Models;

namespace Application.UseCase.Place.UpdatePlace.Interfaces;

public interface IUpdatePlaceStorage : IScopedService
{
    Task UpdatePlace(UpdatePlaceRequest place);
}