using Infrastructure.Database.Entities;
using Infrastructure.Database.Tables.Users;

namespace Infrastructure.Database.Tables.Owner;

public class Owner : BaseEntity<long>
{
    public required string OwnerName { get; init; }

    public List<Place.Place> Places { get; init; } = [];
    public List<Event.Event> Events { get; init; } = [];
    public List<User> Users { get; init; } = [];
}