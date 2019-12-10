using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Stitching;
using HotChocolate.Types;

namespace Demo.Stitching
{
    public class SomeOtherContractExtension
        : ObjectTypeExtension
    {
        protected override void Configure(IObjectTypeDescriptor descriptor)
        {
            descriptor.Name("SomeOtherContract");
            descriptor.Field("expiresInDays")
                .Type<NonNullType<IntType>>()
                .Directive(new ComputedDirective { DependantOn = new NameString[] { "expiryDate" } })
                .Resolver(context =>
                {
                    var obj = context.Parent<IReadOnlyDictionary<string, object>>();
                    var serializedExpiryDate = obj["expiryDate"];
                    var dateType = (ISerializableType)context.ObjectType.Fields["expiryDate"].Type;
                    var offset = (DateTimeOffset)dateType.Deserialize(serializedExpiryDate);
                    return offset.DateTime.Subtract(DateTime.UtcNow).Days;
                });
        }
    }

}
