using Application.Extensions.ActionResult;
using Application.UseCase.Event.CreateEvent.Interfaces;
using Application.UseCase.Event.CreateEvent.Models;
using Application.UserContext;

namespace Application.UseCase.Event.CreateEvent;

public class CreateEventUseCase(ICreateEventStorage storage, IUserContextProvider userProvider)
{
    public async Task<Result> CreateEvent(CreateEventRequest request)
    {
        await storage.CreateEvent(request);

        return Result.Success();
    }
}
