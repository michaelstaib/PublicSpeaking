#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReadMessagesSubscriptionDocument
        : global::StrawberryShake.IDocument
    {
        private const global::System.String _bodyString = 
            @"subscription ReadMessages {
  message: onMessageReceived {
    __typename
    ... Message
    ... on Message {
      id
    }
  }
}

fragment Message on Message {
  id
  direction
  recipient {
    __typename
    ... Participant
    ... on Person {
      id
    }
  }
  sender {
    __typename
    ... Participant
    ... on Person {
      id
    }
  }
  sent
  text
}

fragment Participant on Person {
  name
  email
  isOnline
}";
        private static readonly byte[] _body = global::System.Text.Encoding.UTF8.GetBytes(_bodyString);

        private ReadMessagesSubscriptionDocument()
        {
        }

        public static ReadMessagesSubscriptionDocument Instance { get; } = new ReadMessagesSubscriptionDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Subscription;

        public global::System.ReadOnlySpan<byte> Body => _body;

        public override string ToString()
        {
            return _bodyString;
        }
    }
}
