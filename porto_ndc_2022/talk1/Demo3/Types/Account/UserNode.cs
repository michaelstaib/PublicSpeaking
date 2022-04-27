using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Demo.Types.Account;

[ExtendObjectType(typeof(User))]
public sealed class UserNode
{
    [ID(nameof(User))]
    [BindMember(nameof(User.Id))]
    public int GetId([Parent] User user) => user.Id;

    [BindMember(nameof(User.ImageKey))]
    public string? GetImageUrl([Parent] User user, [Service] IHttpContextAccessor httpContextAccessor)
    {
        if (user.ImageKey is null)
        {
            return null;
        }

        string? scheme = httpContextAccessor.HttpContext?.Request.Scheme;
        string? host = httpContextAccessor.HttpContext?.Request.Host.Value;
        if (scheme is null || host is null)
        {
            return null;
        }

        return $"{scheme}://{host}/images/{user.ImageKey}";
    }
}
