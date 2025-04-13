namespace Application.UseCase.Place.GetPlace.Models;

public class GetPlaceResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string Url { get; set; } = string.Empty;
    public required string Address { get; set; }
    public double Width { get; set; }
    public double Longitude { get; set; }
}