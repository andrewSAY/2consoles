using System;
using System.Threading.Tasks;
using Domain;
using Domain.Exceptions;
using Grpc.Core;

namespace Server
{
    public class CalculatorService : Calculator.CalculatorBase
    {
        private IPowerCalculator _powerCalculator;

        public CalculatorService(IPowerCalculator powerCalculator)
        {
            _powerCalculator = powerCalculator ?? throw new ArgumentNullException(nameof(powerCalculator));
        }

        public override Task<CalculateResponse> Calculate(CalculateRequest request, ServerCallContext context)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            CheckOperationType(request.OperationType);
            CheckValueToCalculate(request.Value);

            var result = _powerCalculator.CalculateCube(request.Value);

            return Task.FromResult(new CalculateResponse
            {
                Value = result
            });
        }

        private void CheckOperationType(string operationType)
        {
            if (string.IsNullOrWhiteSpace(operationType))
            {
                throw new NoExpectedOperationsInArgumentsException();
            }

            if (operationType.ToLower() != "cube")
            {
                throw new NoExpectedOperationsInArgumentsException();
            }
        }

        private void CheckValueToCalculate(int value)
        {
            if (value > 50 || value < 1)
            {
                throw new ArgumentOutOfRangeException($"The value must be between 1 and 50, but was {value}");
            }

            if (value % 2 != 0)
            {
                throw new MustBeEvenValueException();
            }
        }
    }
}
