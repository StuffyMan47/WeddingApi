using Application.Interfaces;
using Application.UseCase.Guest.GetGuest.Models;

namespace Application.UseCase.Guest.GetGuest.Interfaces;

public interface IGetGuestStorage : IScopedService
{
    Task<GetGuestResponse> GetGuest();
}
