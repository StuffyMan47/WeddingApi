namespace Application.UseCase.Place.GetPlacesList.Models;

public class GetPlacesListResponse
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string Url { get; set; } = string.Empty;
    public required string Address { get; set; }
    public double Width { get; set; }
    public double Longitude { get; set; }
}