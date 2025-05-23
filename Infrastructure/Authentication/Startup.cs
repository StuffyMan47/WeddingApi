using Application.Interfaces;
using Application.Interfaces.TokenService;
using Infrastructure.Authentication.JwtTokens;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication;

public static class Startup
{
    internal static IServiceCollection AddStoreWebAuth(this IServiceCollection services, IConfiguration config)
    {
        services.AddScoped<IPasswordService, PasswordService>();
        services.AddScoped<IJwtTokenService, JwtTokenService>();
        services.AddSingleton<IConfigureOptions<JwtBearerOptions>, ConfigureJwtBearerOptions>();
        services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, null!);

        //services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();
        //services.AddScoped<IAuthorizationHandler, PermissionHandler>();

        return services;
    }

    internal static IApplicationBuilder UseStoreWebAuth(this IApplicationBuilder app)
    {
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}