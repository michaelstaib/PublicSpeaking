namespace Demo.Helpers;

public interface IFileStorage
{
    Task<string> UploadAsync(Stream source, CancellationToken cancellationToken);
}