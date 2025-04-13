using Application.Enums;
using Infrastructure.Database.Entities;

namespace Infrastructure.Database.Tables.Guest;

public class Guest : BaseEntity<Guid>
{
    public required string Name { get; set; }
    public bool? IsCome { get; set; }
    public bool? NeedTransfer {  get; set; }
    public string? CoupleName { get; set; }
    public long EventId { get; set; }
    public List<Alcohol>? Alcohol { get; set; } = [];
    public Gender MessageType { get; set; }

    public Event.Event Event { get; set; }
}