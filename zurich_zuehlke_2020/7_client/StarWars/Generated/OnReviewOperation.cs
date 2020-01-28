using System;
using System.Collections;
using System.Collections.Generic;
using StrawberryShake;

namespace StarWarsClientDemo
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class OnReviewOperation
        : IOperation<IOnReview>
    {
        public string Name => "OnReview";

        public IDocument Document => Foo.Default;

        public OperationKind Kind => OperationKind.Subscription;

        public Type ResultType => typeof(IOnReview);

        public Optional<Episode> Episode { get; set; }

        public IReadOnlyList<VariableValue> GetVariableValues()
        {
            var variables = new List<VariableValue>();

            if (Episode.HasValue)
            {
                variables.Add(new VariableValue("episode", "Episode", Episode.Value));
            }

            return variables;
        }
    }
}
