#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessageResultInfo
        : global::StrawberryShake.IOperationResultDataInfo
    {
        private readonly global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> _entityIds;
        private readonly ulong _version;

        public SendMessageResultInfo(
            global::Demo.State.SendMessagePayloadData sendMessage,
            global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> entityIds,
            ulong version)
        {
            SendMessage = sendMessage;
            _entityIds = entityIds
                 ?? throw new global::System.ArgumentNullException(nameof(entityIds));
            _version = version;
        }

        public global::Demo.State.SendMessagePayloadData SendMessage { get; }

        public global::System.Collections.Generic.IReadOnlyCollection<global::StrawberryShake.EntityId> EntityIds => _entityIds;

        public ulong Version => _version;

        public global::StrawberryShake.IOperationResultDataInfo WithVersion(ulong version)
        {
            return new SendMessageResultInfo(
                SendMessage,
                _entityIds,
                _version);
        }
    }
}
