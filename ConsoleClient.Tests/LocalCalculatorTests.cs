using ConsoleClient.Calculators;
using Domain;
using Moq;
using Xunit;

namespace ConsoleClient.Tests
{
    public class LocalCalculatorTests
    {
        [Fact]
        public void Calculate_PassParametersWithCubeOperation_ReturnsExpectedValue()
        {
            var value = 3;
            var expectedResult = 27;
            var powerCalculatorMock = new Mock<IPowerCalculator>();
            powerCalculatorMock.Setup(c => c.CalculateCube(value)).Returns(expectedResult);

            var localCalculator = new LocalCalculator(powerCalculatorMock.Object);
            var parameters = new CommandParameters(value, OperationType.Cube);

            var result = localCalculator.Calculate(parameters);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Calculate_PassParametersWithSquareOperation_ReturnsExpectedValue()
        {
            var value = 3;
            var expectedResult = 9;
            var powerCalculatorMock = new Mock<IPowerCalculator>();
            powerCalculatorMock.Setup(c => c.CalculateSquare(value)).Returns(expectedResult);

            var localCalculator = new LocalCalculator(powerCalculatorMock.Object);
            var parameters = new CommandParameters(value, OperationType.Square);

            var result = localCalculator.Calculate(parameters);

            Assert.Equal(expectedResult, result);
        }
    }
}
