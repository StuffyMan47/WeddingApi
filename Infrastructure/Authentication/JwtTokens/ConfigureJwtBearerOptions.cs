using System.Net;
using System.Security.Claims;
using Application.Extensions;
using Application.Extensions.ActionResult;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace Infrastructure.Authentication.JwtTokens;

public class ConfigureJwtBearerOptions : IConfigureNamedOptions<JwtBearerOptions>
{
    public void Configure(JwtBearerOptions options)
    {
        Configure(string.Empty, options);
    }

    public void Configure(string? name, JwtBearerOptions options)
    {
        if (name != JwtBearerDefaults.AuthenticationScheme)
            return;
        
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new()
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateLifetime = true,
            ValidateAudience = false,
            RoleClaimType = ClaimTypes.Role,
            ClockSkew = TimeSpan.Zero
        };
        options.Events = new()
        {
            OnChallenge = async context =>
            {
                context.HandleResponse();
                if (!context.Response.HasStarted)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    await context.Response.WriteAsJsonAsync(
                        Result.Unauthorized().WithMessage("Доступ только авторизованным пользователям").PackAsApiResponse()
                    );
                }
            },
            OnForbidden = async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.Forbidden;
                await context.Response.WriteAsJsonAsync(
                    Result.PermissionDenied().WithMessage("Нет доступа").PackAsApiResponse()
                );
            },
            OnMessageReceived = context =>
            {
                string? accessToken;
                if (context.Request.Path.ToString().Contains("server-messages"))
                {
                    accessToken = context.Request.Query["access_token"];
                }
                else
                {
                    accessToken = context.Request.Headers.Authorization
                        .FirstOrDefault()?
                        .Split(" ")[^1];
                }

                context.Token = accessToken;
                return Task.CompletedTask;
            },
        };
    }

}