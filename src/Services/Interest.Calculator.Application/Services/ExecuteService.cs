using System.Threading.Tasks;
using Interest.Calculator.AntiCorruption;
using Interest.Calculator.Application.Models;

namespace Interest.Calculator.Application.Services
{
    public class ExecuteService : IExecuteService
    {
        private readonly IRateService _rateService;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        //   rateService:
        //     The rateService param.
        //
        public ExecuteService(IRateService rateService)
        {
            _rateService = rateService;
        }

        public async Task<CalculationResponse> Execute(int initialValue, int months)
        {
            RateResponse rateResponse = await _rateService.FindAsync();

            var result = new CalculateService().Calc(initialValue, months, rateResponse.Rate);

            return new CalculationResponse() { Result = result };
        }
    }
}
