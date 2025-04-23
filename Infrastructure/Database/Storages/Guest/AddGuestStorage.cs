using Application.UseCase.Guest.AddGuest.Interfaces;
using Application.UseCase.Guest.AddGuest.Models;
using Infrastructure.Database.DbContext;

namespace Infrastructure.Database.Storages.Guest;

public class AddGuestStorage(AppDbContext dbContext) : IAddGuestStorage
{
    public async Task AddGuest(AddGuestRequest request)
    {
        dbContext.Guests.Add(new Tables.Guest.Guest
        {
            Name = request.Name,
            IsCome = request.IsCome,
            NeedTransfer = request.NeedTransfer,
            CoupleName = request.Couple,
            EventId = request.EventId,
        });
        await dbContext.SaveChangesAsync();
    }
}
