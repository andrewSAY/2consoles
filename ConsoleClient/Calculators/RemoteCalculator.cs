using System;
using System.Threading.Tasks;
using Domain;
using Server;

namespace ConsoleClient.Calculators
{
    public class RemoteCalculator : ICalculator
    {
        private IServerCalculatorClient _serverClient;
        
        public RemoteCalculator(IServerCalculatorClient serverClient)
        {
            _serverClient = serverClient ?? throw new ArgumentNullException(nameof(serverClient));
        }

        public async Task<int> CalculateAsync(CommandParameters parameters)
        {            
            var request = GetRequestFrom(parameters);

            var result = await  _serverClient.CalculateAsyc(request);

            return result.Value;
        }

        private CalculateRequest GetRequestFrom(CommandParameters parameters)
        {
            return new CalculateRequest
            {
                Value = parameters.Value,
                OperationType = parameters.OperationType.ToString()
            };
        }
    }
}
