#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class PersonEntity
    {
        public global::System.String Name { get; set; } = default!;

        public global::System.String Email { get; set; } = default!;

        public global::System.Boolean IsOnline { get; set; } = default!;

        public global::System.Uri? ImageUri { get; set; }

        public global::System.DateTimeOffset LastSeen { get; set; } = default!;

        public global::Demo.State.MessageConnectionData? Messages { get; set; }
    }
}
