using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WithDI.Web.Models;
using WithDI.Web.Services;

namespace WithDI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherForecaster _weatherForecaster;

        public HomeController(IWeatherForecaster weatherForecaster)
        {
            _weatherForecaster = weatherForecaster;
        }

        [Route("")]
        public IActionResult Index()
        {
            var viewModel = new HomeViewModel();

            var currentWeather = _weatherForecaster.GetCurrentWeather();

            switch (currentWeather.WeatherCondition)
            {
                case WeatherCondition.Sun:
                    viewModel.WeatherDescription = "It's sunny right now.";
                    break;
                case WeatherCondition.Rain:
                    viewModel.WeatherDescription = "We're sorry but it's raining here.";
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
