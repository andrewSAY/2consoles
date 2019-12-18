using System;
using System.Threading.Tasks;
using Domain.Exceptions;
using Server;
using Grpc.Core;
using Grpc.Net.Client;

namespace ConsoleClient.Clients
{
    class ServerCalculatorClient : IServerCalculatorClient
    {
        private string _serverAddress;

        public ServerCalculatorClient(string serverAddress)
        {
            _serverAddress = serverAddress ?? throw new ArgumentNullException(nameof(serverAddress));
        }

        public async Task<CalculateResponse> CalculateAsyc(CalculateRequest calculateRequest)
        {
            try
            {
                var client = GetCalculatorClient();
                return await client.CalculateAsync(calculateRequest);
            }
            catch(RpcException e)
            {
                throw new FailToCallRemoteServerCalculatorException(
                    $"Status details: {e.Status.Detail}, status code: {e.StatusCode}, e.Message: {e.Message}",
                    e);
            }
        }

        private Calculator.CalculatorClient GetCalculatorClient()
        {
            var chanel = GrpcChannel.ForAddress(_serverAddress);
            return new Calculator.CalculatorClient(chanel);
        }
    }
}
