using Application.Interfaces.Settings.Models;

namespace Application.Interfaces.Settings;

public interface IStorewebSettings
{
    string ApplicationName { get; init; }
    AuthSettings AuthSettings { get; init; }
    FileStorageSettings StorageSettings { get; init; }
}