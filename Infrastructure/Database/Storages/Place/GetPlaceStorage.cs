using Application.UseCase.Place.GetPlace.Interfaces;
using Application.UseCase.Place.GetPlace.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Place;

public class GetPlaceStorage(AppDbContext dbContext) : IGetPlaceStorage
{
    public async Task<GetPlaceResponse?> GetPlace(long placeId)
    {
        return await dbContext.Places
            .Select(x => new GetPlaceResponse
            {
                Address = x.Address,
                Name = x.Name,
                Id = x.Id,
                Longitude = x.Longitude,
                Url = x.Url,
                Width = x.Width,
            })
            .FirstOrDefaultAsync(x => x.Id == placeId);
    }
}
