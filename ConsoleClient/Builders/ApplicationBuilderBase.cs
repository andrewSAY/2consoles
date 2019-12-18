using Domain;

namespace ConsoleClient.Builders
{
    public abstract class ApplicationBuilderBase
    {
        public ICalculatorProvider BuldAndGetCalculatorProvider()
        {
            var powerCalculator = GetPowerCalculator();
            var localCalculator = GetLocalCalculator(powerCalculator);
            var serverCalculatorClient = GetServerCalculatorClient();
            var remoteCalculator = GetRemoteCalculator(serverCalculatorClient);
            var provider = GetCalculatorProvider(localCalculator, remoteCalculator);

            return provider;
        }

        protected abstract ICalculator GetLocalCalculator(IPowerCalculator powerCalculator);

        protected abstract ICalculator GetRemoteCalculator(IServerCalculatorClient serverCalculatorClient);

        protected abstract IServerCalculatorClient GetServerCalculatorClient();

        protected abstract IPowerCalculator GetPowerCalculator();

        protected abstract ICalculatorProvider GetCalculatorProvider(ICalculator localCalculator, ICalculator remoteCalculator);
    }
}
