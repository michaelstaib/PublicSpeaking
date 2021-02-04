using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class SendMessageOperation
        : IOperation<ISendMessage>
    {
        public string Name => "SendMessage";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(ISendMessage);

        public Optional<string> Email { get; set; }

        public Optional<string> Text { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Email.HasValue)
            {
                variables.Add(new VariableValue("email", "String", Email.Value));
            }

            if (Text.HasValue)
            {
                variables.Add(new VariableValue("text", "String", Text.Value));
            }

            return variables;
        }
    }
}
