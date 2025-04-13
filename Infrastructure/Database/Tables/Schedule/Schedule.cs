using Infrastructure.Database.Entities;

namespace Infrastructure.Database.Tables.Schedule;

public class Schedule : BaseEntity<long>
{
    public required string Name { get; set; }
    public TimeOnly Time { get; set; }

    public Event.Event Event { get; set; }
}