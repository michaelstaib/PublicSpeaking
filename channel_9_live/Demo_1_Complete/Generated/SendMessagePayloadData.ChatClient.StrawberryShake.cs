#nullable enable

namespace Demo.State
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessagePayloadData
    {
        public SendMessagePayloadData(
            global::System.String typename,
            global::StrawberryShake.EntityId? message = null)
        {
            __typename = typename
                 ?? throw new global::System.ArgumentNullException(nameof(typename));
            Message = message;
        }

        public global::System.String __typename { get; }

        public global::StrawberryShake.EntityId? Message { get; }
    }
}
