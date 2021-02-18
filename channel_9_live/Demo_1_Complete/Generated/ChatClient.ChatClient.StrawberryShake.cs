#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ChatClient
    {
        private readonly GetPeopleQuery _getPeopleQuery;
        private readonly GetMessagesQuery _getMessagesQuery;
        private readonly SendMessageMutation _sendMessageMutation;
        private readonly ReadMessagesSubscription _readMessagesSubscription;

        public ChatClient(
            GetPeopleQuery getPeopleQuery,
            GetMessagesQuery getMessagesQuery,
            SendMessageMutation sendMessageMutation,
            ReadMessagesSubscription readMessagesSubscription)
        {
            _getPeopleQuery = getPeopleQuery
                 ?? throw new global::System.ArgumentNullException(nameof(getPeopleQuery));
            _getMessagesQuery = getMessagesQuery
                 ?? throw new global::System.ArgumentNullException(nameof(getMessagesQuery));
            _sendMessageMutation = sendMessageMutation
                 ?? throw new global::System.ArgumentNullException(nameof(sendMessageMutation));
            _readMessagesSubscription = readMessagesSubscription
                 ?? throw new global::System.ArgumentNullException(nameof(readMessagesSubscription));
        }

        public GetPeopleQuery GetPeopleQuery => _getPeopleQuery;

        public GetMessagesQuery GetMessagesQuery => _getMessagesQuery;

        public SendMessageMutation SendMessageMutation => _sendMessageMutation;

        public ReadMessagesSubscription ReadMessagesSubscription => _readMessagesSubscription;
    }
}
