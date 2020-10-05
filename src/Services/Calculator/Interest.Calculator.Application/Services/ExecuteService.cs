using System.Threading.Tasks;
using Interest.Calculator.Application.Http;
using Interest.Calculator.Application.Interfaces;
using Interest.Calculator.Application.Models;

namespace Interest.Calculator.Application.Services
{
    public class ExecuteService : IExecuteService
    {
        private readonly IRateHttpService _rateService;
        private readonly ICalculateService _calculateService;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   rateService:
        //     The rateService param.
        //
        //   calculateService:
        //     The calculateService param.
        //
        public ExecuteService(IRateHttpService rateService, ICalculateService calculateService)
        {
            _rateService = rateService;
            _calculateService = calculateService;
        }

        //
        // Summary:
        //     /// Method responsible for execute calculate. ///
        //
        // Parameters:
        //   initialValue:
        //     The initialValue param.
        //
        //   months:
        //     The months param.
        //
        public async Task<CalculationResponse> Execute(double initialValue, int months)
        {
            RateResponse rateResponse = await _rateService.FindAsync();

            double result = _calculateService.Calc(initialValue, months, rateResponse.Rate);

            return new CalculationResponse() { Result = result };
        }
    }
}
