#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessageResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<SendMessageResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityMapper<MessageEntity, SendMessage_SendMessage_Message_Message> _sendMessage_SendMessage_Message_MessageFromMessageEntityMapper;
        private readonly global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Recipient_Person> _getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper;
        private readonly global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Sender_Person> _getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper;

        public SendMessageResultFactory(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityMapper<MessageEntity, SendMessage_SendMessage_Message_Message> sendMessage_SendMessage_Message_MessageFromMessageEntityMapper,
            global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Recipient_Person> getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper,
            global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Messages_Nodes_Sender_Person> getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _sendMessage_SendMessage_Message_MessageFromMessageEntityMapper = sendMessage_SendMessage_Message_MessageFromMessageEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(sendMessage_SendMessage_Message_MessageFromMessageEntityMapper));
            _getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper = getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getMessages_PersonByEmail_Messages_Nodes_Recipient_PersonFromPersonEntityMapper));
            _getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper = getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getMessages_PersonByEmail_Messages_Nodes_Sender_PersonFromPersonEntityMapper));
        }

        public SendMessageResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo)
        {
            if (dataInfo is SendMessageResultInfo info)
            {
                return new SendMessageResult(MapNonNullableISendMessage_SendMessage(info.SendMessage));
            }

            throw new global::System.ArgumentException("SendMessageResultInfo expected.");
        }

        private ISendMessage_SendMessage MapNonNullableISendMessage_SendMessage(global::Demo.State.SendMessagePayloadData data)
        {
            ISendMessage_SendMessage returnValue = default!;

            if (data.__typename.Equals("SendMessagePayload", global::System.StringComparison.Ordinal))
            {
                returnValue = new SendMessage_SendMessage_SendMessagePayload(MapNonNullableISendMessage_SendMessage_Message(data.Message ?? throw new global::System.ArgumentNullException()));
            }
            else {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        private ISendMessage_SendMessage_Message MapNonNullableISendMessage_SendMessage_Message(global::StrawberryShake.EntityId entityId)
        {

            if (entityId.Name.Equals("Message", global::System.StringComparison.Ordinal))
            {
                return _sendMessage_SendMessage_Message_MessageFromMessageEntityMapper.Map(
                    _entityStore.GetEntity<MessageEntity>(entityId)
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
