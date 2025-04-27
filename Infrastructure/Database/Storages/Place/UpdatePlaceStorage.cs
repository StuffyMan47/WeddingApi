using Application.UseCase.Place.UpdatePlace.Interfaces;
using Application.UseCase.Place.UpdatePlace.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Place;

public class UpdatePlaceStorage(AppDbContext dbContext) : IUpdatePlaceStorage
{
    public async Task UpdatePlace(UpdatePlaceRequest place)
    {
        await dbContext.Places
            .ExecuteUpdateAsync(s=> s
            .SetProperty(x=>x.Name, x=> x.Name)
            .SetProperty(x=>x.Url, x=> x.Url)
            .SetProperty(x => x.Address, x => x.Address)
            .SetProperty(x => x.Width, x => x.Width)
            .SetProperty(x => x.Longitude, x => x.Longitude));
    }
}
