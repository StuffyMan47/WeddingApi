using Infrastructure.Database.Entities;

namespace Infrastructure.Database.Tables.Photo;

public class Photo : BaseEntity<long>
{
    public required string FileName { get; set; }

    public long EventId { get; set; }
    public Event.Event Event { get; set; }
}