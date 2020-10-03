using System.Threading.Tasks;
using Refit;

namespace Interest.Calculator.AntiCorruption
{
    [Headers(new[] { "Content-Type: application/json;charset=UTF-8", "Accept: application/json;charset=UTF-8" })]
    public interface IRateService
    {
        [Get("/taxaJuros")]
        Task<RateResponse> FindAsync();
    }
}
