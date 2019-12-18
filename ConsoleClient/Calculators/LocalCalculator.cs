using System;
using System.Threading.Tasks;
using Domain;

namespace ConsoleClient.Calculators
{
    public class LocalCalculator : ICalculator
    {
        private readonly IPowerCalculator _powerCalculator;

        public LocalCalculator(IPowerCalculator powerCalculator)
        {
            _powerCalculator = powerCalculator ?? throw new ArgumentNullException(nameof(powerCalculator));
        }

        public Task<int> CalculateAsync(CommandParameters parameters)
        {
            var powerValue = parameters.Value;
            switch (parameters.OperationType)
            {
                case OperationType.Cube: 
                    powerValue = _powerCalculator.CalculateCube(parameters.Value);
                    break;
                case OperationType.Square:
                    powerValue = _powerCalculator.CalculateSquare(parameters.Value);
                    break;
            }

            return Task.FromResult(powerValue);
        }
    }
}
