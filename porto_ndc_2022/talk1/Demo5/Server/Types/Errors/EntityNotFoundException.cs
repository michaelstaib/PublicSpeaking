#pragma warning disable RCS1194
namespace Demo.Types.Errors;

public sealed class EntityNotFoundException : Exception
{
    public EntityNotFoundException(int id)
        : base($"Then entity with the id `{id}` was not found.")
    {
        Id = id;
    }

    public EntityNotFoundException() : base()
    {
    }

    public EntityNotFoundException(string? message) : base(message)
    {
    }

    public EntityNotFoundException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    public int Id { get; }
}
