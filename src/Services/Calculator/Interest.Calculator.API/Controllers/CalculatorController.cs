using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Interest.Calculator.API.Models;
using Interest.Calculator.Application.Interfaces;
using Interest.Calculator.Application.Models;
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
        private readonly IExecuteService _executeService;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        //   executeService:
        //     The executeService param.
        //
        public CalculatorController(ILogger<CalculatorController> logger, IExecuteService executeService)
        {
            _logger = logger;
            _executeService = executeService;
        }

        //
        // Summary:
        //     /// Method responsible for action: Get (GET). ///
        //
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<CalculationResponse>> Get(double valorInicial, int meses)
        {
            _logger.LogInformation("Request: {0}", "Solicitado cálculo de juros.");

            return Ok(await _executeService.Execute(valorInicial, meses));
        }
    }
}
