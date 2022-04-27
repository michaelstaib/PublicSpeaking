using Demo.Types.Errors;

namespace Demo.Types.Account;

[ExtendObjectType(OperationTypeNames.Mutation)]
public sealed class UserMutations
{
    [UseMutationConvention(PayloadFieldName = "updatedUser")]
    public async Task<User?> UpdateUserProfile(
        [GlobalState] string username,
        UpdateUserProfileInput input,
        IFileStorage storage,
        AssetContext context,
        CancellationToken cancellationToken)
    {
        if (username is null)
        {
            throw new NotAuthenticatedException("User Profile");
        }

        User user = await context.Users.FirstAsync(t => t.Name == username, cancellationToken);

        if (input.DisplayName.HasValue)
        {
            user.DisplayName = input.DisplayName.Value;
        }

        if (input.Image.HasValue)
        {
            user.ImageKey = input.Image.Value is null ? null : await TryStoreImage(input.Image.Value, storage, cancellationToken);
        }

        await context.SaveChangesAsync(cancellationToken);
        return user;
    }

    private static async Task<string?> TryStoreImage(
        IFile image,
        IFileStorage storage,
        CancellationToken cancellationToken)
    {
        await using Stream iconStream = image.OpenReadStream();
        return await storage.UploadAsync(iconStream, cancellationToken);
    }
}