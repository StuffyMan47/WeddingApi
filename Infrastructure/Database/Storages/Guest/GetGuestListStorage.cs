using Application.UseCase.Guest.GetGuestsList.Interfaces;
using Application.UseCase.Guest.GetGuestsList.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Guest;

public class GetGuestListStorage(AppDbContext dbContext) : IGetGuestsListStorage
{
    //TODO: Дописать запрос, уточнить параметры для фильтрации и модель ответа
    public async Task<List<GetGuestsListResponse>> GetGuestsList()
    {
        return await dbContext.Guests
            .Select(x => new GetGuestsListResponse
            {
            Name = x.Name,
            })
            .ToListAsync();

    }
}
