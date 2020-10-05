using System;
using System.Net.Mime;
using System.Threading.Tasks;
using Interest.Calculator.API.Models;
using Interest.Calculator.Application.Interfaces;
using Interest.Calculator.Application.Models;
using Interest.Calculator.Application.Services;
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
        //     /// Method responsible for action: Index (GET). ///
        //
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(CalculationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CalculationResponse>> Index(double valorInicial, int meses)
        {
            try
            {
                CalculationResponse calculationResponse = await _executeService.Execute(valorInicial, meses);

                return Ok(calculationResponse);
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResult() { Message = e.Message});
            }
        }
    }
}
