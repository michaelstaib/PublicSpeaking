#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessage_SendMessage_SendMessagePayload
        : ISendMessage_SendMessage_SendMessagePayload
    {
        public SendMessage_SendMessage_SendMessagePayload(ISendMessage_SendMessage_Message message)
        {
            Message = message;
        }

        public ISendMessage_SendMessage_Message Message { get; }
    }
}
