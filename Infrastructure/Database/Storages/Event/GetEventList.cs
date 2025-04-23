using Application.UseCase.Event.GetEventList.Interfaces;
using Application.UseCase.Event.GetEventList.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Event;

internal class GetEventList(AppDbContext dbContext) : IGetEventListStorage
{
    public async Task<List<GetEventListResponse>> GetEventLists(GetEventListFilter request)
    {
        return await dbContext.Events
            .Where(x => x.UserId == request.userId)
            .Select(x => new GetEventListResponse
            {
                Date = x.Date,
                Description = x.Description,
                Id = x.Id,
                Newlyweds = x.Newlyweds,
                WelcomeSpeech = x.WelcomeSpeech,
            }).ToListAsync();
    }
}
