#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class MessageEntity
    {
        public global::System.String Id { get; set; } = default!;

        public Direction Direction { get; set; } = default!;

        public global::StrawberryShake.EntityId Recipient { get; set; } = default!;

        public global::StrawberryShake.EntityId Sender { get; set; } = default!;

        public global::System.DateTimeOffset Sent { get; set; } = default!;

        public global::System.String Text { get; set; } = default!;
    }
}
