using Application.Constants;
using Application.Exception.Base;
using Application.Extensions.ActionResult;
using Infrastructure.Database.Initializers.Seeders;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Database.Initializers.Default;

public static class Startup
{
    public static async Task InitializeBarDatabase(this IServiceProvider services, CancellationToken cancellationToken = default)
    {
        using var scope = services.CreateScope();
        var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();

        var rootTenantId = await seeder.CreateTenantByName(BaseConstants.RootTenantName);
        if (rootTenantId.IsFailure)
            throw new InternalServerException("Не удалось создать тенанта через DataSeeder");

        List<Result> results =
        [

        ];

        var error = results.Find(x => x.IsFailure);
        if (error != null)
            throw new InternalServerException($"Ошибка DataSeeder: {error.Message}");

    }
}