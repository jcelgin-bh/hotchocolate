using System;
using System.Threading.Tasks;
using HotChocolate.Execution.Configuration;
using HotChocolate.Resolvers;
using Xunit;

namespace HotChocolate.Execution
{
    public class QueryExecutionBuilderExtensionsTests
    {
        [Fact]
        public void UseDefaultPipeline1_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseDefaultPipeline(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseDefaultPipeline2_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseDefaultPipeline(null, new QueryExecutionOptions());

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseDefaultPipeline2_OptionsNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseDefaultPipeline(QueryExecutionBuilder.New(), null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseExceptionHandling_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseExceptionHandling(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseInstrumentation_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseInstrumentation(null, default(TracingPreference));

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseOperationExecutor_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseOperationExecutor(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseOperationResolver_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseOperationExecutor(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseQueryParser_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseOperationExecutor(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseRequestTimeout_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseRequestTimeout(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseValidation_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseValidation(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void UseMaxComplexity_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .UseMaxComplexity(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Use1_T_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .Use<object>(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Use2_T_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .Use(null, (sp, next) => new object());

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void Use2_T_FactoryNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .Use<object>(QueryExecutionBuilder.New(), null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void AddExecutionStrategyResolver_BuilderNull_ArgNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .AddExecutionStrategyResolver(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void AddDefaultParser_BuilderNull_ArgumentNullException()
        {
            // arrange
            // act
            Action action = () => QueryExecutionBuilderExtensions
                .AddDefaultParser(null);

            // assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
