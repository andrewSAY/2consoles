using System.Threading.Tasks; 
using Server;

namespace ConsoleClient
{
    public interface IServerCalculatorClient
    {
        Task<CalculateResponse> CalculateAsyc(CalculateRequest calculateRequest);
    }
}
