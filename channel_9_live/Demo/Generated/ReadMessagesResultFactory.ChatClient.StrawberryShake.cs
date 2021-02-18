#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReadMessagesResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<ReadMessagesResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityMapper<MessageEntity, ReadMessages_Message_Message> _readMessages_Message_MessageFromMessageEntityMapper;

        public ReadMessagesResultFactory(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityMapper<MessageEntity, ReadMessages_Message_Message> readMessages_Message_MessageFromMessageEntityMapper)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _readMessages_Message_MessageFromMessageEntityMapper = readMessages_Message_MessageFromMessageEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(readMessages_Message_MessageFromMessageEntityMapper));
        }

        public ReadMessagesResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo)
        {
            if (dataInfo is ReadMessagesResultInfo info)
            {
                return new ReadMessagesResult(MapNonNullableIReadMessages_Message(info.Message));
            }

            throw new global::System.ArgumentException("ReadMessagesResultInfo expected.");
        }

        private IReadMessages_Message MapNonNullableIReadMessages_Message(global::StrawberryShake.EntityId entityId)
        {

            if (entityId.Name.Equals("Message", global::System.StringComparison.Ordinal))
            {
                return _readMessages_Message_MessageFromMessageEntityMapper.Map(
                    _entityStore.GetEntity<MessageEntity>(entityId)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }
    }
}
