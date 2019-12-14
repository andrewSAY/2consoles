using ConsoleClient.Calculators;
using Domain;

namespace ConsoleClient.Builders
{
    public class ApplicationBuilder : ApplicationBuilderBase
    {
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

        protected override ICalculator GetRemoteCalculator(IPowerCalculator powerCalculator)
        {
            return new LocalCalculator(powerCalculator);
        }
    }
}
