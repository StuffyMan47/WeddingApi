using Application.UseCase.Event.DeleteEvent.Interfaces;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Event;

public class DeleteEventStorage(AppDbContext dbContext) : IDeleteEventStorage
{
    public async Task DeleteEvent(long id)
    {
        await dbContext.Events
            .Where(x => x.Id == id)
            .ExecuteDeleteAsync();

        await dbContext.SaveChangesAsync();
    }
}
