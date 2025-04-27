using Application.UseCase.Place.DeletePlace.Interfaces;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Place;

public class DeletePlaceStorage(AppDbContext dbContext) : IDeletePlaceStorage
{
    public async Task DeletePlaceAsync(long placeId)
    {
        await dbContext.Places
            .Where(x=>x.Id == placeId)
            .ExecuteDeleteAsync();
    }
}
