using Infrastructure.Database.Entities;
using Infrastructure.Database.Tables.Users;

namespace Infrastructure.Database.Tables.Event;

public class Event : BaseEntity<long>
{
    public DateTime Date { get; set; }
    public string WelcomeSpeech { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Newlyweds { get; set; } = string.Empty;
    public required long PlaceId { get; set; }
    public required Guid UserId { get; set; }

    public long PhotoId {  get; set; }
    public Photo.Photo? Photo {  get; set; }
    public List<Schedule.Schedule> Schedule { get; set; } = [];
    public List<Guest.Guest> Guests { get; set; } = [];
    public Place.Place? Place { get; set; }
    public User? User { get; set; }
}