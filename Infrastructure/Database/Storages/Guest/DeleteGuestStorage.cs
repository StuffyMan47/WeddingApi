using Application.UseCase.Guest.DeleteGuest.Interfaces;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Guest;

public class DeleteGuestStorage(AppDbContext dbContext) : IDeleteGuestStorage
{
    public async Task DeleteGuest(Guid id)
    {
        await dbContext.Guests.Where(x=>x.Id == id).ExecuteDeleteAsync();

        await dbContext.SaveChangesAsync();
    }
}
