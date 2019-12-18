using System;
using ConsoleClient.Calculators;
using ConsoleClient.Clients;
using Domain;

namespace ConsoleClient.Builders
{
    public class ApplicationBuilder : ApplicationBuilderBase
    {
        private string _serverAddress;

        public ApplicationBuilder(string serverAddress)
        {
            _serverAddress = serverAddress ?? throw new ArgumentNullException(nameof(serverAddress));
        }

        protected override ICalculatorProvider GetCalculatorProvider(ICalculator localCalculator, ICalculator remoteCalculator)
        {
            return new CalculatorProvider(remoteCalculator, localCalculator);
        }

        protected override ICalculator GetLocalCalculator(IPowerCalculator powerCalculator)
        {
            return new LocalCalculator(powerCalculator);
        }

        protected override IPowerCalculator GetPowerCalculator()
        {
            return new PowerCalculator();
        }

        protected override ICalculator GetRemoteCalculator(IServerCalculatorClient serverCalculatorClient)
        {
            return new RemoteCalculator(serverCalculatorClient);
        }

        protected override IServerCalculatorClient GetServerCalculatorClient()
        {
            return new ServerCalculatorClient(_serverAddress);
        }
    }
}
