using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReadMessagesOperation
        : IOperation<IReadMessages>
    {
        public string Name => "ReadMessages";

        public IDocument Document => Queries.Default;

        public OperationKind Kind => OperationKind.Subscription;

        public Type ResultType => typeof(IReadMessages);

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            return Array.Empty<VariableValue>();
        }
    }
}
