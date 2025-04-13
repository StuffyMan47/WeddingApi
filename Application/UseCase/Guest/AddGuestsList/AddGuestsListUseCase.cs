using Application.Extensions.ActionResult;
using Application.UseCase.Guest.AddGuestsList.Interfaces;
using Application.UseCase.Guest.AddGuestsList.Models;

namespace Application.UseCase.Guest.AddGuestsList;

public class AddGuestsListUseCase(IAddGuestsListStorage storage)
{
    public async Task<Result> AddGuestsList(List<AddGuestsListRequest> requests)
    {
        await storage.AddGuestsList(requests);

        return Result.Success();
    }
}
