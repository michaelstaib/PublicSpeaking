#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class ReadMessagesSubscription
    {
        private readonly global::StrawberryShake.IOperationExecutor<IReadMessagesResult> _operationExecutor;

        public ReadMessagesSubscription(global::StrawberryShake.IOperationExecutor<IReadMessagesResult> operationExecutor)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IReadMessagesResult>> Watch(global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest();
            return _operationExecutor.Watch(request, strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest()
        {

            return new global::StrawberryShake.OperationRequest(
                "ReadMessages",
                ReadMessagesSubscriptionDocument.Instance);
        }
    }
}
