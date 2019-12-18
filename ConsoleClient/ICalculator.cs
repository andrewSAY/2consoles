using System.Threading.Tasks;
using Domain;

namespace ConsoleClient
{
    public interface ICalculator
    {
        Task<int> CalculateAsync(CommandParameters parameters);
    }
}
