using System.Reflection;
using Application;
using Application.Interfaces.Settings;
using Application.UserContext;
using Infrastructure.Authentication;
using Infrastructure.Database;
using Infrastructure.Services;
using Infrastructure.Swagger;
using Infrastructure.Validation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class Startup
{
    public static async Task<IServiceCollection> RegisterBarModule(this IServiceCollection services, IConfiguration config, IWebHostEnvironment environment)
    {
        Assembly[] assemblies =
        [
            typeof(Application.Startup).Assembly,
            typeof(Startup).Assembly,
        ];
        services.AddStoreWebAuth(config);
        services.AddHttpContextAccessor();
        services.AddScoped<IUserContextProvider, UserContextProvider>();
        services.AddDataAccessLayer(config, environment);
        services.AddBarApplicationLayer();
        services.AddSingleton<IStorewebSettings, StorewebSettigns>();

        services.AddValidationBuilder();

        services.RegisterServicesByInterfaces(assemblies);
        services.AddSwaggerBuilder();
        return await Task.FromResult(services);
    }
}