#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ChatClient
    {
        private readonly GetMessagesQuery _getMessagesQuery;
        private readonly GetUsersQuery _getUsersQuery;
        private readonly ReadMessagesSubscription _readMessagesSubscription;
        private readonly SendMessageMutation _sendMessageMutation;

        public ChatClient(
            GetMessagesQuery getMessagesQuery,
            GetUsersQuery getUsersQuery,
            ReadMessagesSubscription readMessagesSubscription,
            SendMessageMutation sendMessageMutation)
        {
            _getMessagesQuery = getMessagesQuery
                 ?? throw new global::System.ArgumentNullException(nameof(getMessagesQuery));
            _getUsersQuery = getUsersQuery
                 ?? throw new global::System.ArgumentNullException(nameof(getUsersQuery));
            _readMessagesSubscription = readMessagesSubscription
                 ?? throw new global::System.ArgumentNullException(nameof(readMessagesSubscription));
            _sendMessageMutation = sendMessageMutation
                 ?? throw new global::System.ArgumentNullException(nameof(sendMessageMutation));
        }

        public GetMessagesQuery GetMessagesQuery => _getMessagesQuery;

        public GetUsersQuery GetUsersQuery => _getUsersQuery;

        public ReadMessagesSubscription ReadMessagesSubscription => _readMessagesSubscription;

        public SendMessageMutation SendMessageMutation => _sendMessageMutation;
    }
}
