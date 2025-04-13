using Infrastructure.Database.Entities;

namespace Infrastructure.Database.Tables.Place;

public class Place : BaseEntity<long>
{
    public required string Name { get; set; }
    public string Url { get; set; } = string.Empty;
    public required string Address {  get; set; }
    public double Width { get; set; }
    public double Longitude { get; set; }

    public List<Event.Event> Events { get; set; } = [];
}