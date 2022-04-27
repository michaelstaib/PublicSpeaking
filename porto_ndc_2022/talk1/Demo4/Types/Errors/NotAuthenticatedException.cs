#pragma warning disable RCS1194
namespace Demo.Types.Errors;

public sealed class NotAuthenticatedException : Exception
{
    public NotAuthenticatedException(string featureName)
        : base($"You need to be signed in to use {featureName}.")
    {
    }
}
