using Domain.Exceptions;
using Xunit;

namespace Domain.Tests
{
    public class PowerCalculatorTests
    {
        [Theory]
        [InlineData(100, 10_000)]
        [InlineData(12, 144)]
        [InlineData(13, 169)]
        [InlineData(-3, 9)]
        public void CalculateSquare_Default_RetunsExpectedValue(int value, int expected)
        {
            var calculator = new PowerCalculator();
            var result = calculator.CalculateSquare(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 10_000_00)]
        [InlineData(12, 1728)]
        [InlineData(13, 2197)]
        [InlineData(-2, -8)]
        public void CalculateCube_Default_RetunsExpectedValue(int value, int expected)
        {
            var calculator = new PowerCalculator();
            var result = calculator.CalculateCube(value);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void CalculateSquare_PassMaxOrMinIntValue_ThrowsException(int value)
        {
            var calculator = new PowerCalculator();

            Assert.Throws<OperationResultBiggerPossibleException>(() => calculator.CalculateSquare(value));
        }

        [Theory]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void CalculateCube_PassMaxOrMinIntValue_ThrowsException(int value)
        {
            var calculator = new PowerCalculator();

            Assert.Throws<OperationResultBiggerPossibleException>(() => calculator.CalculateCube(value));
        }
    }
}
