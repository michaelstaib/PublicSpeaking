namespace Demo.Types.Assets;

public sealed class AssetPriceHistoryType : ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor
            .Name("AssetPriceHistory");

        descriptor
            .Field("epoch")
            .Type<NonNullType<IntType>>()
            .FromJson();

        descriptor
            .Field("price")
            .Type<NonNullType<FloatType>>()
            .FromJson();
    }
}