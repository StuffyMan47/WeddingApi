namespace Application.Interfaces.Settings.Models;

public class FileStorageSettings
{
    public required string MasterServer { get; init; }
    public required string VolumeServer { get; init; }
    public required long ImageMaxSizeUpload { get; init; }
    public required List<FileExtension> AllowedExtensions { get; init; } = [];
}

public class FileExtension
{
    public required string Extension { get; init; }
}