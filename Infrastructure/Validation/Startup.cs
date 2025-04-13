using Application.Exception.Base;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure.Database.DbContext;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Validation;

public static class Startup
{
    public static IServiceCollection AddValidationBuilder(this IServiceCollection services)
    {
        ValidatorOptions.Global.LanguageManager.Culture = new("ru");

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblies
        (
            [
                typeof(InternalServerException).Assembly,
                typeof(AppDbContext).Assembly,
            ]
        );
        return services;
    }
}