namespace Application.UseCase.Guest.AddGuestsList.Models;

public class AddGuestsListRequest
{
    public required string Name { get; init; }
    public required bool IsCome { get; init; }
    public required bool NeedTransfer { get; init; }
    public string? Couple { get; init; }
    public required long EventId { get; init; }
}