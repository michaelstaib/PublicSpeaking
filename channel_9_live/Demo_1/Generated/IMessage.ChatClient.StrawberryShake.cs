#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IMessage
    {
        public global::System.String Id { get; }

        public Direction Direction { get; }

        public IGetMessages_PersonByEmail_Messages_Nodes_Recipient Recipient { get; }

        public IGetMessages_PersonByEmail_Messages_Nodes_Sender Sender { get; }

        public global::System.DateTimeOffset Sent { get; }

        public global::System.String Text { get; }
    }
}
