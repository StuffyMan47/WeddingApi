using Application.UseCase.Place.GetPlacesList.Interfaces;
using Application.UseCase.Place.GetPlacesList.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Place;

public class GetPlaceListStorage(AppDbContext dbContext) : IGetPlacesListStorage
{
    public async Task<List<GetPlacesListResponse>> GetPlacesList(GetPlaceListFilter filter)
    {
        return await dbContext.Places
            .Select(x=> new GetPlacesListResponse
            {
                Address = x.Address,
                Name = x.Name,
                Id = x.Id,
                Longitude = x.Longitude,
                Url = x.Url,
                Width = x.Width
            })
            .ToListAsync();
    }
}
