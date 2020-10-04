using System.Threading.Tasks;
using Interest.Calculator.Application.Models;
using Refit;

namespace Interest.Calculator.Application.Http
{
    [Headers(new[] { "Content-Type: application/json;charset=UTF-8", "Accept: application/json;charset=UTF-8" })]
    public interface IRateHttpService
    {
        [Get("/taxaJuros")]
        Task<RateResponse> FindAsync();
    }
}
