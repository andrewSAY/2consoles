using System;
using System.Threading.Tasks;
using Server;
using ConsoleClient.Calculators;
using Domain;
using Domain.Exceptions;
using Moq;
using Xunit;

namespace ConsoleClient.Tests
{
    public class RemoteCalculatorTests
    {
        [Fact]
        public async Task Calculate_PassParametersWithCubeOperation_ReturnsExpectedValue()
        {
            var value = 3;
            var expectedResult = 27;
            var serverClientMock = new Mock<IServerCalculatorClient>();
            serverClientMock.Setup(c => c.CalculateAsyc(It.IsAny<CalculateRequest>()))
                .Returns(Task.FromResult(new CalculateResponse { Value = expectedResult }));

            var remoteCalculator = new RemoteCalculator(serverClientMock.Object);
            var parameters = new CommandParameters(value, OperationType.Cube);

            var result = await remoteCalculator.CalculateAsync(parameters);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public async Task Calculate_PassParametersWithSquareOperation_ThrowException()
        {
            var serverClientMock = new Mock<IServerCalculatorClient>();
            serverClientMock.Setup(c => c.CalculateAsyc(It.IsAny<CalculateRequest>()))
                .Callback(() => throw new FailToCallRemoteServerCalculatorException(string.Empty, new Exception()));

            var localCalculator = new RemoteCalculator(serverClientMock.Object);
            var parameters = new CommandParameters(4, OperationType.Square);

            await Assert.ThrowsAsync<FailToCallRemoteServerCalculatorException>(async () => await localCalculator.CalculateAsync(parameters));
        }

        [Fact]
        public async Task Calculate_PassOddValue_ThrowException()
        {
            var serverClientMock = new Mock<IServerCalculatorClient>();
            serverClientMock.Setup(c => c.CalculateAsyc(It.IsAny<CalculateRequest>()))
                .Callback(() => throw new FailToCallRemoteServerCalculatorException(string.Empty, new Exception()));

            var localCalculator = new RemoteCalculator(serverClientMock.Object);
            var parameters = new CommandParameters(3, OperationType.Cube);

            await Assert.ThrowsAsync<FailToCallRemoteServerCalculatorException>(async () => await localCalculator.CalculateAsync(parameters));
        }
    }
}
