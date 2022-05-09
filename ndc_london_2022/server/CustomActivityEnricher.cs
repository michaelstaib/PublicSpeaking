using System.Diagnostics;
using System.Text;
using HotChocolate.Diagnostics;
using Microsoft.Extensions.ObjectPool;

namespace Demo;

public sealed class CustomActivityEnricher : ActivityEnricher
{
    public CustomActivityEnricher(
        ObjectPool<StringBuilder> stringBuilderPoolPool, 
        InstrumentationOptions options) 
        : base(stringBuilderPoolPool, options)
    {
    }

    protected override string CreateRootActivityName(Activity activity, Activity root, string displayName)
    {
        return displayName;
    }
}