#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetPeople_People_Nodes_Person
        : IGetPeople_People_Nodes_Person
    {
        public GetPeople_People_Nodes_Person(
            global::System.String name,
            global::System.String email,
            global::System.Boolean isOnline,
            global::System.Uri? imageUri,
            global::System.DateTimeOffset lastSeen)
        {
            Name = name;
            Email = email;
            IsOnline = isOnline;
            ImageUri = imageUri;
            LastSeen = lastSeen;
        }

        public global::System.String Name { get; }

        public global::System.String Email { get; }

        public global::System.Boolean IsOnline { get; }

        public global::System.Uri? ImageUri { get; } = default!;

        public global::System.DateTimeOffset LastSeen { get; }
    }
}
