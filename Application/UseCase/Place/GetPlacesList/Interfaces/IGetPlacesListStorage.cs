using Application.Interfaces;
using Application.UseCase.Place.GetPlacesList.Models;

namespace Application.UseCase.Place.GetPlacesList.Interfaces;

public interface IGetPlacesListStorage : IScopedService
{
    Task<List<GetPlacesListResponse>> GetPlacesList(GetPlaceListFilter filter);
}