using Application.Extensions.ActionResult;
using Application.UseCase.Event.DeleteEvent.Interfaces;

namespace Application.UseCase.Event.DeleteEvent;

public class DeleteEventUseCase(IDeleteEventStorage storage)
{
    public async Task<Result> DeleteEvent(long id)
    {
        await storage.DeleteEvent(id);

        return Result.Success();
    }
}
