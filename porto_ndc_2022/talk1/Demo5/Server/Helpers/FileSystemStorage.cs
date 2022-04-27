namespace Demo.Helpers;

public sealed class FileSystemStorage : IFileStorage
{
    private readonly string _rootDirectory;

    public FileSystemStorage(string rootDirectory)
    {
        _rootDirectory = rootDirectory ?? throw new ArgumentNullException(nameof(rootDirectory));

        if (!Directory.Exists(_rootDirectory))
        {
            Directory.CreateDirectory(_rootDirectory);
        }
    }

    public async Task<string> UploadAsync(Stream source, CancellationToken cancellationToken)
    {
        string key = Guid.NewGuid().ToString("N") + ".png";
        string fileName = System.IO.Path.Combine(_rootDirectory, key);
        await using FileStream stream = File.Create(fileName);
        await source.CopyToAsync(stream, cancellationToken);
        return key;
    }
}
