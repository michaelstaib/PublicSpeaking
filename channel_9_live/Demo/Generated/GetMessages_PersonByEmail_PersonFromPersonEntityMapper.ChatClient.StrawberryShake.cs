#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessages_PersonByEmail_PersonFromPersonEntityMapper
        : global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Person>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityMapper<MessageEntity, GetMessages_PersonByEmail_Messages_Nodes_Message> _getMessages_PersonByEmail_Messages_Nodes_MessageFromMessageEntityMapper;
        private readonly global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Recipient_Person> _getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper;
        private readonly global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Sender_Person> _getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper;

        public GetMessages_PersonByEmail_PersonFromPersonEntityMapper(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityMapper<MessageEntity, GetMessages_PersonByEmail_Messages_Nodes_Message> getMessages_PersonByEmail_Messages_Nodes_MessageFromMessageEntityMapper,
            global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Recipient_Person> getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper,
            global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Sender_Person> getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _getMessages_PersonByEmail_Messages_Nodes_MessageFromMessageEntityMapper = getMessages_PersonByEmail_Messages_Nodes_MessageFromMessageEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getMessages_PersonByEmail_Messages_Nodes_MessageFromMessageEntityMapper));
            _getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper = getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper));
            _getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper = getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper));
        }

        public GetMessages_PersonByEmail_Person Map(PersonEntity entity)
        {
            return new GetMessages_PersonByEmail_Person(MapIGetMessages_PersonByEmail_Messages(entity.Messages));
        }

        private IGetMessages_PersonByEmail_Messages? MapIGetMessages_PersonByEmail_Messages(global::Demo.State.MessageConnectionData data)
        {
            if (data == default)
            {
                return null;
            }

            IGetMessages_PersonByEmail_Messages returnValue = default!;

            if (data?.__typename.Equals("MessageConnection", global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new GetMessages_PersonByEmail_Messages_MessageConnection(MapIGetMessages_PersonByEmail_Messages_NodesArray(data.Nodes));
            }
            else {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        private global::System.Collections.Generic.IReadOnlyList<IGetMessages_PersonByEmail_Messages_Nodes?>? MapIGetMessages_PersonByEmail_Messages_NodesArray(global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.EntityId?>? list)
        {
            if (list == default)
            {
                return null;
            }

            var iGetMessages_PersonByEmail_Messages_Nodess = new global::System.Collections.Generic.List<IGetMessages_PersonByEmail_Messages_Nodes?>();

            foreach (global::StrawberryShake.EntityId? child in list)
            {
                iGetMessages_PersonByEmail_Messages_Nodess.Add(MapIGetMessages_PersonByEmail_Messages_Nodes(child));
            }

            return iGetMessages_PersonByEmail_Messages_Nodess;
        }

        private IGetMessages_PersonByEmail_Messages_Nodes? MapIGetMessages_PersonByEmail_Messages_Nodes(global::StrawberryShake.EntityId? entityId)
        {
            if (entityId == default)
            {
                return null;
            }


            if (entityId.Value.Name.Equals("Message", global::System.StringComparison.Ordinal))
            {
                return _getMessages_PersonByEmail_Messages_Nodes_MessageFromMessageEntityMapper.Map(
                    _entityStore.GetEntity<MessageEntity>(entityId.Value)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }

        private IGetMessages_PersonByEmail_Messages_Nodes_Recipient MapNonNullableIGetMessages_PersonByEmail_Messages_Nodes_Recipient(global::StrawberryShake.EntityId entityId)
        {

            if (entityId.Name.Equals("Person", global::System.StringComparison.Ordinal))
            {
                return _getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper.Map(
                    _entityStore.GetEntity<PersonEntity>(entityId)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }

        private IGetMessages_PersonByEmail_Messages_Nodes_Sender MapNonNullableIGetMessages_PersonByEmail_Messages_Nodes_Sender(global::StrawberryShake.EntityId entityId)
        {

            if (entityId.Name.Equals("Person", global::System.StringComparison.Ordinal))
            {
                return _getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper.Map(
                    _entityStore.GetEntity<PersonEntity>(entityId)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }
    }
}
