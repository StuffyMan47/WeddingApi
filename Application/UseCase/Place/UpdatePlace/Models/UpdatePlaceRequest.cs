namespace Application.UseCase.Place.UpdatePlace.Models;

public class UpdatePlaceRequest
{
    public string? Name { get; set; }
    public string? Url { get; set; }
    public string? Address {  get; set; }
    public double? Width { get; set; }
    public double? Longitude { get; set; }
}