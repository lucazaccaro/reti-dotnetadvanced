using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using WithoutDI.Web.Models;
using WithoutDI.Web.Services;

namespace WithoutDI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController()
        {
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            var weatherForecaster = new WeatherForecaster();
            var currentWeather = weatherForecaster.GetCurrentWeather();

            switch (currentWeather.WeatherCondition)
            {
                case WeatherCondition.Sun:
                    viewModel.WeatherDescription = "It's sunny right now.";
                    break;
                case WeatherCondition.Rain:
                    viewModel.WeatherDescription = "We're sorry but it's raining here";
                    break;
                default:
                    viewModel.WeatherDescription = "We don't have the latest weather";
                    break;
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
