using Application.Exception.Base;
using Application.Interfaces.Settings;
using Application.Interfaces.Settings.Models;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services;

public class StorewebSettigns : IStorewebSettings
{
    public string ApplicationName { get; init; }
    public AuthSettings AuthSettings { get; init; }
    public FileStorageSettings StorageSettings { get; init; }

    public StorewebSettigns(IConfiguration configuration)
    {
        var applicationSection = configuration.GetSection("Storeweb.Application");

        ApplicationName = applicationSection["Name"] ?? "Unknown application name";
        AuthSettings = configuration.GetSection("Authentication").Get<AuthSettings>() ?? throw new InternalServerException("Не заданы настройки аутентификации");
    }
}
