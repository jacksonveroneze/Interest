using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Interest.Calculator.AntiCorruption;
using Interest.Calculator.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interest.Calculator.API.Controllers
{
    [ApiController]
    [Route("calculajuros")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;
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
        public CalculatorController(ILogger<CalculatorController> logger, IRateService rateService)
        {
            _logger = logger;
            _rateService = rateService;
        }

        //
        // Summary:
        //     /// Method responsible for action: Index (GET). ///
        //
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CalculationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CalculationResponse>> Index(int valorInicial, int meses)
        {
            _logger.LogInformation("Request: {0}", "Solicitado cálculo juros.");

            RateResponse rateResponse = await _rateService.FindAsync();

            double result = Math.Pow(Convert.ToDouble(valorInicial) * (1 + rateResponse.Rate), Convert.ToDouble(meses));


            return Ok(new CalculationResponse { Result = result });
        }
    }
}
