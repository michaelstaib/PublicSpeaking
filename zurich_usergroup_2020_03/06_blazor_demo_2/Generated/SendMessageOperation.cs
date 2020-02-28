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
        public string Name => "sendMessage";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Mutation;

        public Type ResultType => typeof(ISendMessage);

        public Optional<string> To { get; set; }

        public Optional<string> Message { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (To.HasValue)
            {
                variables.Add(new VariableValue("to", "String", To.Value));
            }

            if (Message.HasValue)
            {
                variables.Add(new VariableValue("message", "String", Message.Value));
            }

            return variables;
        }
    }
}
