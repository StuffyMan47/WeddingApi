namespace Application.UseCase.Event.CreateEvent.Models;

public record struct CreateEventRequest(DateTime Date, string Description, string Newlyweds, string WelcomeSpeech, long PlaceId, long OwnerId, Guid UserId);

public class CreateEventRequestValidator : AbstractValidator<CreateEventRequest>
{
    public CreateEventRequestValidator()
    {
        RuleFor(x => x.Date).NotEmpty().WithName("Дата проведения мероприятия");
        RuleFor(x => x.PlaceId).NotEmpty().WithName("Место проведения");
    }
}