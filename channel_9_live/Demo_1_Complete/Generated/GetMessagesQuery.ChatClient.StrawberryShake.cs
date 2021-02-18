#nullable enable

namespace Demo
{
    [global::System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public partial class GetMessagesQuery
    {
        private readonly global::StrawberryShake.IOperationExecutor<IGetMessagesResult> _operationExecutor;
        private readonly global::StrawberryShake.Serialization.IInputValueFormatter _stringFormatter;

        public GetMessagesQuery(
            global::StrawberryShake.IOperationExecutor<IGetMessagesResult> operationExecutor,
            global::StrawberryShake.Serialization.ISerializerResolver serializerResolver)
        {
            _operationExecutor = operationExecutor
                 ?? throw new global::System.ArgumentNullException(nameof(operationExecutor));
            _stringFormatter = serializerResolver.GetInputValueFormatter("String");
        }

        public async global::System.Threading.Tasks.Task<global::StrawberryShake.IOperationResult<IGetMessagesResult>> ExecuteAsync(
            global::System.String email,
            global::System.Threading.CancellationToken cancellationToken = default)
        {
            var request = CreateRequest(email);
            
            return await _operationExecutor
                .ExecuteAsync(
                    request,
                    cancellationToken)
                .ConfigureAwait(false);
        }

        public global::System.IObservable<global::StrawberryShake.IOperationResult<IGetMessagesResult>> Watch(
            global::System.String email,
            global::StrawberryShake.ExecutionStrategy? strategy = null)
        {
            var request = CreateRequest(email);
            return _operationExecutor.Watch(request, strategy);
        }

        private global::StrawberryShake.OperationRequest CreateRequest(global::System.String email)
        {
            var arguments = new global::System.Collections.Generic.Dictionary<global::System.String, global::System.Object?>();
            arguments.Add("email", FormatEmail(email));

            return new global::StrawberryShake.OperationRequest(
                "GetMessages",
                GetMessagesQueryDocument.Instance,
                arguments);
        }

        private global::System.Object? FormatEmail(global::System.String value)
        {
            if (value == default)
            {
                return null;
            }

            return _stringFormatter.Format(value);
        }
    }
}
