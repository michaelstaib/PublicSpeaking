#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessagesResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<GetMessagesResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Person> _getMessages_PersonByEmail_PersonFromPersonEntityMapper;

        public GetMessagesResultFactory(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityMapper<PersonEntity, GetMessages_PersonByEmail_Person> getMessages_PersonByEmail_PersonFromPersonEntityMapper)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _getMessages_PersonByEmail_PersonFromPersonEntityMapper = getMessages_PersonByEmail_PersonFromPersonEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getMessages_PersonByEmail_PersonFromPersonEntityMapper));
        }

        public GetMessagesResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo)
        {
            if (dataInfo is GetMessagesResultInfo info)
            {
                return new GetMessagesResult(MapNonNullableIGetMessages_PersonByEmail(info.PersonByEmail));
            }

            throw new global::System.ArgumentException("GetMessagesResultInfo expected.");
        }

        private IGetMessages_PersonByEmail MapNonNullableIGetMessages_PersonByEmail(global::StrawberryShake.EntityId entityId)
        {

            if (entityId.Name.Equals("Person", global::System.StringComparison.Ordinal))
            {
                return _getMessages_PersonByEmail_PersonFromPersonEntityMapper.Map(
                    _entityStore.GetEntity<PersonEntity>(entityId)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }
    }
}
