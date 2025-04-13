using Application.Interfaces;
using Application.UseCase.Event.GetEventList.Models;

namespace Application.UseCase.Event.GetEvent.Interfaces;

public interface IGetEventStorage : IScopedService
{
    Task<GetEventListResponse> GetEvent(long id);
}
