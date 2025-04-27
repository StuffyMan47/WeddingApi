using Application.UseCase.Place.AddPlace.Interfaces;
using Application.UseCase.Place.AddPlace.Models;
using Infrastructure.Database.DbContext;

namespace Infrastructure.Database.Storages.Place;

public class AddPlaceStorage(AppDbContext dbContext) : IAddPlaceStorage
{
    public async Task CreatePlace(AddPlaceRequest request)
    {
        dbContext.Places.Add(new Tables.Place.Place
        {
            Address = request.Address,
            Name = request.Name,
            Longitude = request.Longitude,
            Width = request.Width,
            Url = request.Url,
        });

        await dbContext.SaveChangesAsync();
    }
}
