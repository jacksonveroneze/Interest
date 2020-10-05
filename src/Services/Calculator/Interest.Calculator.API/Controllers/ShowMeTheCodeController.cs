using System.Net.Mime;
using Interest.Calculator.API.Models;
using Interest.Calculator.Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Interest.Calculator.API.Controllers
{
    [ApiController]
    [Route("showmethecode")]
    public class ShowMeTheCodeController : ControllerBase
    {
        private readonly ILogger<ShowMeTheCodeController> _logger;

        //
        // Summary:
        //     /// Method responsible for initializing the controller. ///
        //
        // Parameters:
        //   logger:
        //     The logger param.
        //
        public ShowMeTheCodeController(ILogger<ShowMeTheCodeController> logger)
            => _logger = logger;

        //
        // Summary:
        //     /// Method responsible for action: Index (GET). ///
        //
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(typeof(ShowMeTheCodeResult), StatusCodes.Status200OK)]
        public ActionResult<CalculationResponse> Index()
            => Ok(new ShowMeTheCodeResult() {Address = "https://github.com/jacksonveroneze/Interest"});
    }
}
