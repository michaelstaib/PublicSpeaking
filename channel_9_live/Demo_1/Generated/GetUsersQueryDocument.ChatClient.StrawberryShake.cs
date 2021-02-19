#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetUsersQueryDocument
        : global::StrawberryShake.IDocument
    {
        private const global::System.String _bodyString = 
            @"query GetUsers {
  people {
    __typename
    nodes {
      __typename
      ... User
      ... on Person {
        id
      }
    }
  }
}

fragment User on Person {
  ... Participant
  lastSeen
  imageUri
}

fragment Participant on Person {
  name
  email
  isOnline
}";
        private static readonly byte[] _body = global::System.Text.Encoding.UTF8.GetBytes(_bodyString);

        private GetUsersQueryDocument()
        {
        }

        public static GetUsersQueryDocument Instance { get; } = new GetUsersQueryDocument();

        public global::StrawberryShake.OperationKind Kind => global::StrawberryShake.OperationKind.Query;

        public global::System.ReadOnlySpan<byte> Body => _body;

        public override string ToString()
        {
            return _bodyString;
        }
    }
}
