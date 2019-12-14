using System;
using ConsoleClient.Calculators;
using Domain;
using AutoFixture;
using Moq;
using Xunit;

namespace ConsoleClient.Tests
{
    public class CalculatorProviderTests
    {
        [Theory]
        [InlineData(50)]
        [InlineData(68)]
        [InlineData(8)]
        public void Provide_EvenValuePassed_ReturnsRemoteCalculator(int value)
        {
            var localCalculator = new Mock<ICalculator>().Object;
            var remoteCalculator = new Mock<ICalculator>().Object;
            var provider = new CalculatorProvider(remoteCalculator, localCalculator);
            
            var parameters = new CommandParameters(value, OperationType.Cube);
            var result = provider.Provide(parameters);

            Assert.Same(remoteCalculator, result);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(67)]
        [InlineData(89)]
        public void Provide_OddValuePassed_ReturnsRemoteCalculator(int value)
        {
            var localCalculator = new Mock<ICalculator>().Object;
            var remoteCalculator = new Mock<ICalculator>().Object;
            var provider = new CalculatorProvider(remoteCalculator, localCalculator);

            var parameters = new CommandParameters(value, OperationType.Cube);
            var result = provider.Provide(parameters);

            Assert.Same(localCalculator, result);
        }
    }
}
