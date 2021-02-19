#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetUsersResultFactory
        : global::StrawberryShake.IOperationResultDataFactory<GetUsersResult>
    {
        private readonly global::StrawberryShake.IEntityStore _entityStore;
        private readonly global::StrawberryShake.IEntityMapper<PersonEntity, GetUsers_People_Nodes_Person> _getUsers_People_Nodes_PersonFromPersonEntityMapper;

        public GetUsersResultFactory(
            global::StrawberryShake.IEntityStore entityStore,
            global::StrawberryShake.IEntityMapper<PersonEntity, GetUsers_People_Nodes_Person> getUsers_People_Nodes_PersonFromPersonEntityMapper)
        {
            _entityStore = entityStore
                 ?? throw new global::System.ArgumentNullException(nameof(entityStore));
            _getUsers_People_Nodes_PersonFromPersonEntityMapper = getUsers_People_Nodes_PersonFromPersonEntityMapper
                 ?? throw new global::System.ArgumentNullException(nameof(getUsers_People_Nodes_PersonFromPersonEntityMapper));
        }

        public GetUsersResult Create(global::StrawberryShake.IOperationResultDataInfo dataInfo)
        {
            if (dataInfo is GetUsersResultInfo info)
            {
                return new GetUsersResult(MapIGetUsers_People(info.People));
            }

            throw new global::System.ArgumentException("GetUsersResultInfo expected.");
        }

        private IGetUsers_People? MapIGetUsers_People(global::Demo.State.PersonConnectionData data)
        {
            if (data == default)
            {
                return null;
            }

            IGetUsers_People returnValue = default!;

            if (data?.__typename.Equals("PersonConnection", global::System.StringComparison.Ordinal) ?? false)
            {
                returnValue = new GetUsers_People_PersonConnection(MapIGetUsers_People_NodesArray(data.Nodes));
            }
            else {
                throw new global::System.NotSupportedException();
            }
            return returnValue;
        }

        private global::System.Collections.Generic.IReadOnlyList<IGetUsers_People_Nodes?>? MapIGetUsers_People_NodesArray(global::System.Collections.Generic.IReadOnlyList<global::StrawberryShake.EntityId?>? list)
        {
            if (list == default)
            {
                return null;
            }

            var iGetUsers_People_Nodess = new global::System.Collections.Generic.List<IGetUsers_People_Nodes?>();

            foreach (global::StrawberryShake.EntityId? child in list)
            {
                iGetUsers_People_Nodess.Add(MapIGetUsers_People_Nodes(child));
            }

            return iGetUsers_People_Nodess;
        }

        private IGetUsers_People_Nodes? MapIGetUsers_People_Nodes(global::StrawberryShake.EntityId? entityId)
        {
            if (entityId == default)
            {
                return null;
            }


            if (entityId.Value.Name.Equals("Person", global::System.StringComparison.Ordinal))
            {
                return _getUsers_People_Nodes_PersonFromPersonEntityMapper.Map(
                    _entityStore.GetEntity<PersonEntity>(entityId.Value)
                        ?? throw new global::StrawberryShake.GraphQLClientException());
            }
            throw new global::System.NotSupportedException();
        }
    }
}
