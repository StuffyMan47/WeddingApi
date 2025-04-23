using Application.UseCase.Event.GetEvent.Interfaces;
using Application.UseCase.Event.GetEventList.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Event;

public class GetEventStorage(AppDbContext dbContext) : IGetEventStorage
{
    public async Task<GetEventListResponse> GetEvent(long id)
    {
        return await dbContext.Events
            .Select(x=> new GetEventListResponse
            {
                Id = x.Id,
                Date = x.Date,
                Description = x.Description,
                Newlyweds = x.Newlyweds,
                WelcomeSpeech = x.WelcomeSpeech,
            })
            .FirstAsync(x => x.Id == id);
    }
}
