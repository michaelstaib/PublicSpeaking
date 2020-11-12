using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessagesOperation
        : IOperation<IGetMessages>
    {
        public string Name => "GetMessages";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Query;

        public Type ResultType => typeof(IGetMessages);

        public Optional<string> Email { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Email.HasValue)
            {
                variables.Add(new VariableValue("email", "String", Email.Value));
            }

            return variables;
        }
    }
}
