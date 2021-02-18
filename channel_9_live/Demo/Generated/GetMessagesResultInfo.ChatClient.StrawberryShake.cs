#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessagesResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly ulong _version;

        public GetMessagesResultInfo(
            global::StrawberryShake.EntityId personByEmail,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            ulong version)
        {
            PersonByEmail = personByEmail;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::StrawberryShake.EntityId PersonByEmail { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public ulong Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(ulong version)
        {
            return new GetMessagesResultInfo(
                PersonByEmail,
                _entityIds,
                _version);
        }
    }
}
