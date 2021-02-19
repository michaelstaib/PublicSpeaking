#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public interface IUser
        : IParticipant
    {
        public global::System.DateTimeOffset LastSeen { get; }

        public global::System.Uri? ImageUri { get; }
    }
}
