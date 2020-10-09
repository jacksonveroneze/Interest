using System.Net.Mime;
using Interest.Rate.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interest.Rate.API.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class RateController : ControllerBase
    {
        private readonly ILogger<RateController> _logger;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        public RateController(ILogger<RateController> logger)
            => _logger = logger;

        //
        // Summary:
        //     /// Method responsible for action: Index (GET). ///
        //
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public ActionResult<RateResponse> Index()
        {
            _logger.LogInformation("Request: {0}", "Solicitado taxa de juros.");

            return Ok(new RateResponse { Rate = 0.01 });
        }
    }
}
