using System;
using ConsoleClient.Commands;
using Domain;
using Xunit;

namespace ConsoleClient.Tests
{
    public class CommandParametersClientTests
    {
        [Theory]
        [InlineData(10, "square", OperationType.Square)]
        [InlineData(15, "cube", OperationType.Cube)]
        [InlineData(15, "cUbe", OperationType.Cube)]
        public void Constructor_Default_ReturnsExpectedObject(int value, string operationName, OperationType expectedOperationType)
        {
            var args = new string[] { value.ToString(), operationName };
            var parameters = new CommandParametersClient(args);

            Assert.Equal(value, parameters.Value);
            Assert.Equal(expectedOperationType, parameters.OperationType);
        }

        [Theory]
        [InlineData("-10", "square")]
        [InlineData("115", "cube")]
        [InlineData("15", "cUb")]
        [InlineData("15,75", "cube")]
        [InlineData("asdasd", "cube")]
        [InlineData("square", "100")]
        public void Constructor_WrongValuesOrOperationNames_TheowsException(string value, string operationName)
        {
            var args = new string[] { value.ToString(), operationName };
            Assert.ThrowsAny<Exception>(() => new CommandParametersClient(args));
        }

    }
}
