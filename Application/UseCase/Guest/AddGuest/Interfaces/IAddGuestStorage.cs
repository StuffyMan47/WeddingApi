using Application.Interfaces;
using Application.UseCase.Guest.AddGuest.Models;

namespace Application.UseCase.Guest.AddGuest.Interfaces;

public interface IAddGuestStorage : IScopedService
{
    Task AddGuest(AddGuestRequest request);
}
