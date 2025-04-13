using Application.Interfaces;

namespace Application.UseCase.Event.DeleteEvent.Interfaces;

public interface IDeleteEventStorage : IScopedService
{
    Task DeleteEvent(long id);
}
