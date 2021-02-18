#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReadMessagesResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly ulong _version;

        public ReadMessagesResultInfo(
            global::StrawberryShake.EntityId message,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            ulong version)
        {
            Message = message;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::StrawberryShake.EntityId Message { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public ulong Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(ulong version)
        {
            return new ReadMessagesResultInfo(
                Message,
                _entityIds,
                _version);
        }
    }
}
