namespace Application.UseCase.Place.AddPlace.Models;

public record struct AddPlaceRequest(string Name, string Url, string Address, long OwnerId, double Longitude, double Width);