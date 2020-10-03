using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interest.Calculator.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ILogger<CalculatorController> _logger;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        //
        // Summary:
        //     /// Method responsible for action: New (POST). ///
        //
        // Parameters:
        //   command:
        //     The command param.
        //
        [HttpPost("read")]
        [Produces(MediaTypeNames.Application.Json)]
        //[ProducesResponseType(typeof(CreateCertificateResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Read()
        {
            _logger.LogInformation("Request: {0}", "Generate new certificate");

            return Ok();
        }
    }
}
