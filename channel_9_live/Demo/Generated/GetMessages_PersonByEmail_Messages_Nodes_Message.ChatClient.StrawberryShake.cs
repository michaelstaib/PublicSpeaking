#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessages_PersonByEmail_Messages_Nodes_Message
        : IGetMessages_PersonByEmail_Messages_Nodes_Message
    {
        public GetMessages_PersonByEmail_Messages_Nodes_Message(
            global::System.String id,
            global::System.String text,
            Direction direction,
            IGetMessages_PersonByEmail_Messages_Nodes_Recipient recipient,
            IGetMessages_PersonByEmail_Messages_Nodes_Sender sender,
            global::System.DateTimeOffset sent)
        {
            Id = id;
            Text = text;
            Direction = direction;
            Recipient = recipient;
            Sender = sender;
            Sent = sent;
        }

        public global::System.String Id { get; }

        public global::System.String Text { get; }

        public Direction Direction { get; }

        public IGetMessages_PersonByEmail_Messages_Nodes_Recipient Recipient { get; }

        public IGetMessages_PersonByEmail_Messages_Nodes_Sender Sender { get; }

        public global::System.DateTimeOffset Sent { get; }
    }
}
