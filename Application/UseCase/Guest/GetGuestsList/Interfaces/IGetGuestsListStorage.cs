using Application.Interfaces;
using Application.UseCase.Guest.GetGuestsList.Models;

namespace Application.UseCase.Guest.GetGuestsList.Interfaces;

public interface IGetGuestsListStorage : IScopedService
{
    public Task<List<GetGuestsListResponse>> GetGuestsList();
}
