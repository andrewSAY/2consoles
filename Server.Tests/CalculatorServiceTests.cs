using System;
using Domain;
using Domain.Exceptions;
using Grpc.Core;
using Moq;
using Xunit;

namespace Server.Tests
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData("cube")]
        [InlineData("CubE")]
        [InlineData("cUbe")]
        public void Calculate_PassedCaseInsensitiveOperationType_ReturnsExpectedValue(string operationType)
        {
            var value = 4;
            var expectedValue = 64;
            var powerCalculatorMock = new Mock<IPowerCalculator>();
            powerCalculatorMock.Setup(c => c.CalculateCube(value)).Returns(expectedValue);
            var service = new CalculatorService(powerCalculatorMock.Object);

            var request = new CalculateRequest
            { 
                OperationType = operationType,
                Value = value
            };
            var callContextMock = new Mock<ServerCallContext>().Object;
            var result = service.Calculate(request, callContextMock).Result;

            Assert.Equal(expectedValue, result.Value);
        }

        [Fact]
        public void Calculate_PassedNullRequest_ThrowsException()
        {
            var powerCalculatorMock = new Mock<IPowerCalculator>().Object;
            var callContextMock = new Mock<ServerCallContext>().Object;
            var service = new CalculatorService(powerCalculatorMock);

            CalculateRequest request = null;

            Assert.ThrowsAsync<ArgumentNullException>(() => service.Calculate(request, callContextMock));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void Calculate_PassedEmptyOrWhitespaceAsOperationType_ThrowsException(string operatioType)
        {
            var powerCalculatorMock = new Mock<IPowerCalculator>().Object;
            var callContextMock = new Mock<ServerCallContext>().Object;
            var service = new CalculatorService(powerCalculatorMock);

            var request = new CalculateRequest
            {
                OperationType = operatioType,
            };

            Assert.ThrowsAsync<NoExpectedOperationsInArgumentsException>(() => service.Calculate(request, callContextMock));
        }

        [Theory]
        [InlineData("Square")]
        [InlineData("cub")]
        public void Calculate_PassedNoSupportedOperationType_ThrowsException(string operatioType)
        {
            var powerCalculatorMock = new Mock<IPowerCalculator>().Object;
            var callContextMock = new Mock<ServerCallContext>().Object;
            var service = new CalculatorService(powerCalculatorMock);

            var request = new CalculateRequest
            {
                OperationType = operatioType,
            };

            Assert.ThrowsAsync<NoExpectedOperationsInArgumentsException>(() => service.Calculate(request, callContextMock));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(51)]
        public void Calculate_PassedValueMore50OrLess1_ThrowsException(int wrongValue)
        {
            var powerCalculatorMock = new Mock<IPowerCalculator>().Object;
            var callContextMock = new Mock<ServerCallContext>().Object;
            var service = new CalculatorService(powerCalculatorMock);

            var request = new CalculateRequest
            {
                OperationType = "cube",
                Value = wrongValue
            };

            Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.Calculate(request, callContextMock));
        }


        [Theory]
        [InlineData(3)]
        [InlineData(15)]
        [InlineData(49)]
        public void Calculate_PassedOddValue_ThrowsException(int wrongValue)
        {
            var powerCalculatorMock = new Mock<IPowerCalculator>().Object;
            var callContextMock = new Mock<ServerCallContext>().Object;
            var service = new CalculatorService(powerCalculatorMock);

            var request = new CalculateRequest
            {
                OperationType = "cube",
                Value = wrongValue
            };

            Assert.ThrowsAsync<MustBeEvenValueException>(() => service.Calculate(request, callContextMock));
        }
    }
}
