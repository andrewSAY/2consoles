using System;
using System.Threading.Tasks;
using ConsoleClient.Builders;
using ConsoleClient.Commands;

namespace ConsoleClient
{
    class Program
    {
        private static ICalculatorProvider _calculatorProvider;

        static Program()
        {
            var builder = new ApplicationBuilder("http://localhost:5001");
            _calculatorProvider = builder.BuldAndGetCalculatorProvider();
            UseUnencryptedGrpc();
        }

        private static void UseUnencryptedGrpc()
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
        }

        static async Task Main(string[] args)
        {
            try
            {
                var command = new CommandParametersClient(args);
                var calculator = _calculatorProvider.Provide(command);
                var result = await calculator.CalculateAsync(command);

                Console.WriteLine(result);

            }
            catch (Exception e)
            {
                PrintException(e);
            }
        }

        private static void PrintException(Exception exception)
        {
            while(exception != null)
            {
                Console.WriteLine(exception);
                exception = exception.InnerException;
            }
        }
    }
}
