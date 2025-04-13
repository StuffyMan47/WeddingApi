using Application.Extensions.ActionResult;
using Application.UseCase.Guest.AddGuest.Interfaces;
using Application.UseCase.Guest.AddGuest.Models;

namespace Application.UseCase.Guest.AddGuest;

public class AddGuestUseCase(IAddGuestStorage storage)
{
    public async Task<Result> AddGuest(AddGuestRequest request)
    {
        await storage.AddGuest(request);

        return Result.Success();
    }
}
