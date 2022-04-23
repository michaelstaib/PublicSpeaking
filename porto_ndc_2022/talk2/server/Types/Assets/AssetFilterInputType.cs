using HotChocolate.Data.Filters;

namespace Demo.Types.Assets;

public sealed class AssetFilterInputType : FilterInputType<Asset>
{
    protected override void Configure(IFilterInputTypeDescriptor<Asset> descriptor)
    {
        descriptor.BindFieldsExplicitly();
        descriptor.Field(t => t.Symbol);
        descriptor.Field(t => t.Slug);
        descriptor.Field(t => t.Name);
        descriptor.Field(t => t.Price);
    }
}