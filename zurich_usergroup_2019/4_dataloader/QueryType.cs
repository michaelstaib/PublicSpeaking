using GreenDonut;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace HotChocolate.Examples.Paging
{
    public class QueryType
        : ObjectType<Query>
    {
        protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
        {
            descriptor.Field(t => t.GetMessages(default))
                .UsePaging<MessageType>()
                .UseFiltering()
                .UseSorting();

            descriptor.Field("usersByCountry")
                .Argument("country", a => a.Type<NonNullType<StringType>>())
                .Type<NonNullType<ListType<NonNullType<UserType>>>>()
                .Resolver(ctx =>
                {
                    var userRepository = ctx.Service<UserRepository>();

                    IDataLoader<string, User[]> userDataLoader =
                        ctx.GroupDataLoader<string, User>(
                            "usersByCountry",
                            userRepository.GetUsersByCountry);

                    return userDataLoader.LoadAsync(ctx.Argument<string>("country"));
                });
        }
    }
}
