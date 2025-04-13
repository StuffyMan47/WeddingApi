using Application.UseCase.Event.CreateEvent;
using Application.UseCase.Event.DeleteEvent;
using Application.UseCase.Event.GetEvent;
using Application.UseCase.Event.GetEventList;
using Application.UseCase.Guest.AddGuest;
using Application.UseCase.Guest.AddGuestsList;
using Application.UseCase.Guest.DeleteGuest;
using Application.UseCase.Guest.GetGuest;
using Application.UseCase.Guest.GetGuestsList;
using Application.UseCase.Place.AddPlace;
using Application.UseCase.Place.DeletePlace;
using Application.UseCase.Place.GetPlace;
using Application.UseCase.Place.GetPlacesList;
using Application.UseCase.Place.UpdatePlace;
using Application.UseCase.User.CreateUser;
using Application.UseCase.User.GenerateToken;
using Application.UseCase.User.Login;
using Application.UseCase.User.RefreshToken;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Startup
{
    public static IServiceCollection AddBarApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<LoginUseCase>();
        services.AddScoped<CreateUserUseCase>();
        services.AddScoped<GenerateTokenUseCase>();
        services.AddScoped<RefreshTokenUseCase>();
        services.AddScoped<AddGuestUseCase>();
        services.AddScoped<AddGuestsListUseCase>();
        services.AddScoped<DeleteGuestUseCase>();
        services.AddScoped<GetGuestUseCase>();
        services.AddScoped<GetGuestsListUseCase>();
        services.AddScoped<CreateEventUseCase>();
        services.AddScoped<DeleteEventUseCase>();
        services.AddScoped<GetEventUseCase>();
        services.AddScoped<GetEventListUseCase>();
        services.AddScoped<AddPlaceUseCase>();
        services.AddScoped<DeletePlaceUseCase>();
        services.AddScoped<GetPlaceUseCase>();
        services.AddScoped<GetPlacesListUseCase>();
        services.AddScoped<UpdatePlaceUseCase>();
        
        return services;
    }
}