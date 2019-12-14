using Domain;

namespace ConsoleClient
{
    public interface ICalculatorProvider
    {
        ICalculator Provide(CommandParameters commandParameters);
    }
}
