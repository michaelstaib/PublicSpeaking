using System;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Execution;
using HotChocolate.Types;
using Snapshooter.Xunit;
using Xunit;

namespace Testing
{
    public class MyTests
    {
        [Fact]
        public void Schema_Snapshot()
        {
            // arrange
            // act
            ISchema schema = SchemaBuilder.New()
                .AddQueryType(d => d
                    .Name("Query")
                    .Field("foo")
                    .Resolver("bar"))
                .Create();

            // assert
            schema.ToString().MatchSnapshot();
        }

        [Fact]
        public async Task Schema_Integration_Test()
        {
            // arrange
            ISchema schema = SchemaBuilder.New()
                .AddQueryType(d =>
                {
                    d.Name("Query");
                    d.Field("foo").Resolver("bar");
                    d.Field("baz").Resolver(DateTimeOffset.UtcNow);
                })
                .Create();

            IQueryExecutor executor = schema.MakeExecutable();

            // act
            IExecutionResult result = await executor.ExecuteAsync(
                QueryRequestBuilder.New()
                    .SetQuery("{ foo baz }")
                    .Create());

            // assert
            result.MatchSnapshot(matchOptions => matchOptions.IgnoreField("Data.baz"));
        }
    }
}
