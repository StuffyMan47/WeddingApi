using Application.Interfaces;
using Application.UseCase.Event.GetEventList.Models;

namespace Application.UseCase.Event.GetEventList.Interfaces;

public interface IGetEventListStorage : IScopedService
{
    public Task<List<GetEventListResponse>> GetEventLists(GetEventListFilter request);
}
