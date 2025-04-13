namespace Application.UseCase.Guest.AddGuest.Models;

public record struct AddGuestRequest(string Name, bool IsCome, bool NeedTransfer, string Couple, long EventId);
