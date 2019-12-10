using HotChocolate.Resolvers;
using HotChocolate.Types;
using GreenDonut;
using MongoDB.Bson;

namespace HotChocolate.Examples.Paging
{
    public class MessageType
        : ObjectType<Message>
    {
        protected override void Configure(IObjectTypeDescriptor<Message> descriptor)
        {
            descriptor.Field(t => t.Id).Type<NonNullType<IdType>>();
            descriptor.Field(t => t.Text).Type<NonNullType<StringType>>();
            descriptor.Field("createdBy").Type<NonNullType<UserType>>().Resolver(ctx =>
            {
                UserRepository repository = ctx.Service<UserRepository>();
                return repository.GetUserAsync(ctx.Parent<Message>().UserId, ctx.RequestAborted);
            });
            descriptor.Field("replyTo").Type<MessageType>().Resolver(async ctx =>
            {
                ObjectId? replyToId = ctx.Parent<Message>().ReplyToId;
                if (replyToId.HasValue)
                {
                    MessageRepository repository = ctx.Service<MessageRepository>();
                    return await repository.GetMessageById(replyToId.Value);
                }
                return null;
            });
            descriptor.Ignore(t => t.UserId);
            descriptor.Ignore(t => t.ReplyToId);
        }
    }
}
