using Application.Interfaces;
using Application.UseCase.Guest.AddGuestsList.Models;

namespace Application.UseCase.Guest.AddGuestsList.Interfaces;

public interface IAddGuestsListStorage : IScopedService
{
    Task AddGuestsList(List<AddGuestsListRequest> requests);
}
