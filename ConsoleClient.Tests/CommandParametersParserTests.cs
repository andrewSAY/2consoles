using Xunit;
using ConsoleClient.Commands;
using Domain;
using Domain.Exceptions;

namespace ConsoleClient.Tests
{
    public class CommandParametersParserTests
    {
        [Theory]
        [InlineData(3, "cube", OperationType.Cube)]
        [InlineData(3, "Square", OperationType.Square)]
        public void Parse_Default_SuccessParsing(int argumentInt, string argumentString, OperationType expectedOperationType)
        {
            var args = new string[] { argumentInt.ToString(), argumentString };
            var parser = new CommandParametersParser(args);

            var result = parser.Parse();

            Assert.Equal(expectedOperationType, result.OperationType);
            Assert.Equal(argumentInt, result.Value);
        }


        [Fact]
        public void Parse_ArgsHasMore2Elements_SuccessParsing()
        {
            var args = new string[] { "1", "cube", "3" };
            var parser = new CommandParametersParser(args);

            var result = parser.Parse();

            Assert.Equal(OperationType.Cube, result.OperationType);
            Assert.Equal(1, result.Value);
        }

        [Fact]
        public void Parse_ArgsHasLessThen2Elements_ThrowsException()
        {
            var args = new string[] { "1" };
            var parser = new CommandParametersParser(args);

            Assert.Throws<TooMuchShortArgumentsListException>(() => parser.Parse());
        }

        [Theory]
        [InlineData("one")]
        [InlineData("1.5")]
        public void Parse_ArgsDoesntHaveIntElement_ThrowsException(string wrongIntArgument)
        {
            var args = new string[] { wrongIntArgument, "cube", "3" };
            var parser = new CommandParametersParser(args);

            Assert.Throws<NoIntegerArgumentException>(() => parser.Parse());
        }

        [Fact]
        public void Parse_ArgsDoesntHaveSquareOrCubeStringElement_ThrowsException()
        {
            var args = new string[] { "1", "circle", "3" };
            var parser = new CommandParametersParser(args);

            Assert.Throws<NoExpectedOperationsInArgumentsException>(() => parser.Parse());
        }

        [Theory]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(null)]
        public void Parse_ArgsHasWhiteSpaceOrNullOrEmptyAsSecondArgument_ThrowsException(string emptyOperationName)
        {
            var args = new string[] { "1", emptyOperationName, "3" };
            var parser = new CommandParametersParser(args);

            Assert.Throws<NoExpectedOperationsInArgumentsException>(() => parser.Parse());
        }
    }
}
