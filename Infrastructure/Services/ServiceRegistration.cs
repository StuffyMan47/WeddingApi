using System.Reflection;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Services;

public static class ServiceRegistration
{
    public static IServiceCollection RegisterServicesByInterfaces(this IServiceCollection services, Assembly[] assemblies) =>
        services
            .AddServicesByInterface(typeof(ITransientService), ServiceLifetime.Transient, assemblies)
            .AddServicesByInterface(typeof(IScopedService), ServiceLifetime.Scoped, assemblies);

    private static IServiceCollection AddServicesByInterface(this IServiceCollection services, Type interfaceType, ServiceLifetime lifetime, Assembly[] assemblies)
    {
        var interfaceTypes =
            assemblies
                .SelectMany(s => s.GetTypes())
                .Where(t => interfaceType.IsAssignableFrom(t)
                            && t is { IsClass: true, IsAbstract: false })
                .Select(t => new
                {
                    Service = t.GetInterfaces().FirstOrDefault(),
                    Implementation = t
                })
                .Where(t => t.Service is not null
                            && interfaceType.IsAssignableFrom(t.Service));

        foreach (var type in interfaceTypes)
        {
            services.AddServiceByInterface(type.Service!, type.Implementation, lifetime);
        }

        return services;
    }

    private static IServiceCollection AddServiceByInterface(this IServiceCollection services, Type serviceType, Type implementationType, ServiceLifetime lifetime) =>
        lifetime switch
        {
            ServiceLifetime.Transient => services.AddTransient(serviceType, implementationType),
            ServiceLifetime.Scoped => services.AddScoped(serviceType, implementationType),
            ServiceLifetime.Singleton => services.AddSingleton(serviceType, implementationType),
            _ => throw new ArgumentException("Invalid lifeTime", nameof(lifetime))
        };
}