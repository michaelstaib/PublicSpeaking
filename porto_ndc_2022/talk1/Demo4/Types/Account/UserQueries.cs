namespace Demo.Types.Account;

[ExtendObjectType(OperationTypeNames.Query)]
public sealed class UserQueries
{
    public async Task<User?> GetMeAsync(
        [GlobalState] string? username,
        AssetContext context,
        CancellationToken cancellationToken)
    {
        if (username is null)
        {
            return null;
        }

        return await context.Users.FirstOrDefaultAsync(t => t.Name == username, cancellationToken);
    }
}
