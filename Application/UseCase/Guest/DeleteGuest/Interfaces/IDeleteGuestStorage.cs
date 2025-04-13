using Application.Interfaces;

namespace Application.UseCase.Guest.DeleteGuest.Interfaces;

public interface IDeleteGuestStorage : IScopedService
{
    Task DeleteGuest(Guid id);
}
