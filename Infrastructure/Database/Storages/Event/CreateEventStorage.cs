using Application.UseCase.Event.CreateEvent.Interfaces;
using Application.UseCase.Event.CreateEvent.Models;
using Infrastructure.Database.DbContext;

namespace Infrastructure.Database.Storages.Event;

internal class CreateEventStorage(AppDbContext dbContext) : ICreateEventStorage
{
    public async Task CreateEvent(CreateEventRequest request)
    {
        await dbContext.Events.AddAsync(new Tables.Event.Event
        {
            UserId = request.UserId,
            Date = request.Date,
            Description = request.Description,
            Newlyweds = request.Newlyweds,
            WelcomeSpeech = request.WelcomeSpeech,
            PlaceId = request.PlaceId,
        });

        await dbContext.SaveChangesAsync();
    }
}
