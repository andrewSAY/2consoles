using System;
using ConsoleClient.Builders;
using ConsoleClient.Commands;

namespace ConsoleClient
{
    class Program
    {
        private static ICalculatorProvider _calculatorProvider;

        static Program()
        {
            var builder = new ApplicationBuilder();
            _calculatorProvider = builder.BuldAndGetCalculatorProvider();
        }

        static void Main(string[] args)
        {
            var command = new CommandParametersClient(args);
            var calculator = _calculatorProvider.Provide(command);
            var result = calculator.Calculate(command);

            Console.WriteLine(result);
        }
    }
}
