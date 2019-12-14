using System;
using Domain;

namespace ConsoleClient.Calculators
{
    public class CalculatorProvider : ICalculatorProvider
    {
        private enum CalculatorType { Local, Remote };
        private readonly ICalculator _remoteCalculator;
        private readonly ICalculator _localCalculator;
       
        public CalculatorProvider(ICalculator remoteCalculator, ICalculator localCalculator)
        {
            _remoteCalculator = remoteCalculator ?? throw new ArgumentNullException(nameof(remoteCalculator));
            _localCalculator = localCalculator ?? throw new ArgumentNullException(nameof(localCalculator));
        }

        public ICalculator Provide(CommandParameters commandParameters)
        {
            if(commandParameters.Value % 2 != 0)
            {
                return _localCalculator;
            }
            else
            {
                return _remoteCalculator;
            }
        }
    }
}
