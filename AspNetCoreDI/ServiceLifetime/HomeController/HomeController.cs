using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceLifetime.Services;
using System.Collections.Generic;

namespace ServiceLifetime.HomeController
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly GuidService _guidService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(GuidService guidService, ILogger<HomeController> logger)
        {
            _guidService = guidService;
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index()
        {
            var guid = _guidService.GetGuid();
            var logMessage = $"Controller: The GUID from GuidService (Scope 1) is {guid}";
            _logger.LogInformation(logMessage);

            var messages = new List<string>
            {
                HttpContext.Items["MiddlewareGuid1"].ToString(),
                HttpContext.Items["MiddlewareGuid2"].ToString(),
                logMessage
            };

            var response = string.Join("\n", messages);

            return Ok(response);
        }
    }
}
