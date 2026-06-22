using LeaseMate.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace LeaseMate.Infrastructure.Services;

public class FileStorageService
{
    private readonly IConfiguration _configuration;

    public FileStorageService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetBasePath()
    {
        var path = _configuration["Storage:BasePath"] ?? "storage";
        EnsureDirectoryExists(path);
        return path;
    }

    public string GetUploadPath()
    {
        var path = _configuration["Storage:UploadPath"] ?? Path.Combine(GetBasePath(), "uploads");
        EnsureDirectoryExists(path);
        return path;
    }

    public string GetGeneratedDocumentsPath()
    {
        var path = _configuration["Storage:GeneratedDocumentsPath"]
                   ?? Path.Combine(GetBasePath(), "generated-documents");

        EnsureDirectoryExists(path);
        return path;
    }

    public string GetContractUploadPath(int contractId)
    {
        var path = Path.Combine(GetUploadPath(), $"contract-{contractId}");
        EnsureDirectoryExists(path);
        return path;
    }

    public string GetContractGeneratedDocumentsPath(int contractId)
    {
        var path = Path.Combine(GetGeneratedDocumentsPath(), $"contract-{contractId}");
        EnsureDirectoryExists(path);
        return path;
    }

    public async Task<StoredFileResult> SaveFileAsync(
        Stream fileStream,
        string originalFileName,
        string directoryPath,
        string? contentType = null,
        CancellationToken cancellationToken = default)
    {
        EnsureDirectoryExists(directoryPath);

        var safeFileName = GetSafeFileName(originalFileName);
        var storedFileName = $"{Guid.NewGuid():N}_{safeFileName}";
        var fullPath = Path.Combine(directoryPath, storedFileName);

        await using var outputStream = new FileStream(fullPath, FileMode.CreateNew);
        await fileStream.CopyToAsync(outputStream, cancellationToken);

        var fileInfo = new FileInfo(fullPath);

        return new StoredFileResult
        {
            OriginalFileName = originalFileName,
            StoredFileName = storedFileName,
            FilePath = fullPath,
            ContentType = contentType,
            SizeInBytes = fileInfo.Length
        };
    }

    public async Task<byte[]> ReadFileAsync(
        string filePath,
        CancellationToken cancellationToken = default)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found.", filePath);

        return await File.ReadAllBytesAsync(filePath, cancellationToken);
    }

    public Stream OpenRead(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException("File not found.", filePath);

        return File.OpenRead(filePath);
    }

    public Task DeleteFileAsync(string filePath)
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }

        return Task.CompletedTask;
    }

    public bool FileExists(string filePath)
    {
        return File.Exists(filePath);
    }

    public string GetSafeFileName(string fileName)
    {
        var name = Path.GetFileName(fileName);

        foreach (var invalidChar in Path.GetInvalidFileNameChars())
        {
            name = name.Replace(invalidChar, '-');
        }

        return name;
    }

    private static void EnsureDirectoryExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }
}