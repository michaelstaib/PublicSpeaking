#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessages_PersonByEmail_Messages_Nodes_Recipient_Person
        : IGetMessages_PersonByEmail_Messages_Nodes_Recipient_Person
    {
        public GetMessages_PersonByEmail_Messages_Nodes_Recipient_Person(
            global::System.String name,
            global::System.String email,
            global::System.Boolean isOnline)
        {
            Name = name;
            Email = email;
            IsOnline = isOnline;
        }

        public global::System.String Name { get; }

        public global::System.String Email { get; }

        public global::System.Boolean IsOnline { get; }
    }
}
