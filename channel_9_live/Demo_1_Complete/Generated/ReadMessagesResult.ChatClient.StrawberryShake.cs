#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReadMessagesResult
        : IReadMessagesResult
    {
        public ReadMessagesResult(IReadMessages_Message message)
        {
            Message = message;
        }

        public IReadMessages_Message Message { get; }
    }
}
