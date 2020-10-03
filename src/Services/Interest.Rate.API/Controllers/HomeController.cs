﻿using Microsoft.AspNetCore.Mvc;

namespace Interest.Rate.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : ControllerBase
    {
        //
        // Summary:
        //     /// Method responsible for redirect to swagger page. ///
        //
        [Route("")]
        [HttpGet]
        public IActionResult Index() => Redirect("/swagger");
    }
}
