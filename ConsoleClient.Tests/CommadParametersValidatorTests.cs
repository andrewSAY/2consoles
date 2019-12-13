using System;
using Xunit;
using Domain;

namespace ConsoleClient.Tests
{
    public class CommadParametersValidatorTests
    {
        [Theory]
        [InlineData(15, OperationType.Cube)]
        [InlineData(94, OperationType.Cube)]
        [InlineData(71, OperationType.Square)]
        public void Check_Default_NotThrowException(int value, OperationType operationType)
        {
            var validator = new CommandParametersValidator(value, operationType);

            validator.Check();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(101)]
        [InlineData(214)]
        public void Check_TheValueIsMore100OrLess1_ThrowsException(int value)
        {
            var validator = new CommandParametersValidator(value, OperationType.Cube);

            Assert.Throws<ArgumentOutOfRangeException>(() => validator.Check());
        }
    }
}
