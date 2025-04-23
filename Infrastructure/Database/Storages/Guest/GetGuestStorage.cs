using Application.UseCase.Guest.GetGuest.Interfaces;
using Application.UseCase.Guest.GetGuest.Models;
using Infrastructure.Database.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Storages.Guest;

public class GetGuestStorage(AppDbContext dbContext) : IGetGuestStorage
{
    //TODO: Дописать запрос, уточнить параметры для фильтрации и модель ответа
    public async Task<GetGuestResponse> GetGuest()
    {
        return await dbContext.Guests
            .Select(x => new GetGuestResponse
            {
                Name = x.Name,
            }).FirstAsync();
    }
}
