using Application.Extensions.ActionResult;
using Application.UseCase.Guest.GetGuestsList.Interfaces;
using Application.UseCase.Guest.GetGuestsList.Models;

namespace Application.UseCase.Guest.GetGuestsList;

public class GetGuestsListUseCase(IGetGuestsListStorage storage)
{
    public async Task<Result<List<GetGuestsListResponse>>> GetGuestsList()
    {
        var result = await storage.GetGuestsList();

        return Result<List<GetGuestsListResponse>>.Success(result);
    }
}
