using HotChocolate.Types;

namespace HelloWorld
{
    public class QueryType : ObjectType<Query> 
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor) 
        {
            descriptor.Field(t => t.Hello()).Type<NonNullType<StringType>>();
        }
    }
}
