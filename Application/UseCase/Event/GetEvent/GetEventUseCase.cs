using Application.Extensions.ActionResult;
using Application.UseCase.Event.GetEvent.Interfaces;
using Application.UseCase.Event.GetEventList.Models;

namespace Application.UseCase.Event.GetEvent;

public class GetEventUseCase(IGetEventStorage storage)
{
    public async Task<Result<GetEventListResponse>> GetEvent(long id)
    {
        var result = await storage.GetEvent(id);

        return Result<GetEventListResponse>.Success(result);
    }
}
