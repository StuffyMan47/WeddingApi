using Application.Extensions.ActionResult;
using Application.UseCase.Guest.DeleteGuest.Interfaces;

namespace Application.UseCase.Guest.DeleteGuest;

public class DeleteGuestUseCase(IDeleteGuestStorage storage)
{
    public async Task<Result> DeleteGuest(Guid id)
    {
        await storage.DeleteGuest(id);

        return Result.Success();
    }
}
