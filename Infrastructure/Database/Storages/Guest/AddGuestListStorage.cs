using Application.UseCase.Guest.AddGuestsList.Interfaces;
using Application.UseCase.Guest.AddGuestsList.Models;
using Infrastructure.Database.DbContext;

namespace Infrastructure.Database.Storages.Guest;

public class AddGuestListStorage(AppDbContext dbContext) : IAddGuestsListStorage
{
    public async Task AddGuestsList(List<AddGuestsListRequest> requests)
    {
        dbContext.Guests.AddRange(requests.Select(x => new Tables.Guest.Guest
        {
            Name = x.Name,
            IsCome = x.IsCome,
            CoupleName = x.Couple,
            EventId = x.EventId,
            NeedTransfer = x.NeedTransfer,
        }));
        await dbContext.SaveChangesAsync();
    }
}
