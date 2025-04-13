using Application.Extensions.ActionResult;
using Application.UseCase.Guest.GetGuest.Interfaces;
using Application.UseCase.Guest.GetGuest.Models;

namespace Application.UseCase.Guest.GetGuest;

public class GetGuestUseCase(IGetGuestStorage storage)
{
    public async Task<Result<GetGuestResponse>> GetGuest()
    {
        var result = await storage.GetGuest();

        return Result<GetGuestResponse>.Success(result);
    }
}
