#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessageMutationDocument
        : global::StrawberryShake.IDocument
    {
        private const global::System.String _bodyString = 
            @"mutation SendMessage($email: String!, $text: String!) {
  sendMessage(input: { recipientEmail: $email, text: $text }) {
    __typename
    message {
      __typename
      ... Message
      ... on Message {
        id
      }
    }
  }
}

fragment Message on Message {
  id
  text
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
}

fragment Participant on Person {
  name
  email
  isOnline
}";
        private static readonly byte[] _body = global::System.Text.Encoding.UTF8.GetBytes(_bodyString);

        private SendMessageMutationDocument()
        {
        }

        public static SendMessageMutationDocument Instance { get; } = new SendMessageMutationDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Mutation;

        public global::System.ReadOnlySpan<byte> Body => _body;

        public override string ToString()
        {
            return _bodyString;
        }
    }
}
