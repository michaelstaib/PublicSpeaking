#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessagesQueryDocument
        : global::StrawberryShake.IDocument
    {
        private const global::System.String _bodyString = 
            @"query GetMessages($email: String!) {
  personByEmail(email: $email) {
    __typename
    messages(order_by: { sent: ASC }) {
      __typename
      nodes {
        __typename
        ... Message
        ... on Message {
          id
        }
      }
    }
    ... on Person {
      id
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

        private GetMessagesQueryDocument()
        {
        }

        public static GetMessagesQueryDocument Instance { get; } = new GetMessagesQueryDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Query;

        public global::System.ReadOnlySpan<byte> Body => _body;

        public override string ToString()
        {
            return _bodyString;
        }
    }
}
