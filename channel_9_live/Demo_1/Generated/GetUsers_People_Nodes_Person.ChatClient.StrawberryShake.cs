#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetUsers_People_Nodes_Person
        : IGetUsers_People_Nodes_Person
    {
        public GetUsers_People_Nodes_Person(
            global::System.String name,
            global::System.String email,
            global::System.Boolean isOnline,
            global::System.DateTimeOffset lastSeen,
            global::System.Uri? imageUri)
        {
            Name = name;
            Email = email;
            IsOnline = isOnline;
            LastSeen = lastSeen;
            ImageUri = imageUri;
        }

        public global::System.String Name { get; }

        public global::System.String Email { get; }

        public global::System.Boolean IsOnline { get; }

        public global::System.DateTimeOffset LastSeen { get; }

        public global::System.Uri? ImageUri { get; } = default!;
    }
}
