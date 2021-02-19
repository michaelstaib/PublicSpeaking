#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessageResult
        : ISendMessageResult
    {
        public SendMessageResult(ISendMessage_SendMessage sendMessage)
        {
            SendMessage = sendMessage;
        }

        public ISendMessage_SendMessage SendMessage { get; }
    }
}
