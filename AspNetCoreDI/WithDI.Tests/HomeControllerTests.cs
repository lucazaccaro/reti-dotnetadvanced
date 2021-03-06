using Microsoft.AspNetCore.Mvc;
using Moq;
using WithDI.Web.Controllers;
using WithDI.Web.Models;
using WithDI.Web.Services;
using Xunit;

namespace WithDI.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void ReturnsExpectedViewModel_WhenWeatherIsSunny()
        {
            var mockWeatherForecaster = new Mock<IWeatherForecaster>();
            mockWeatherForecaster.Setup(w => w.GetCurrentWeather()).Returns(new WeatherResult
            {
                WeatherCondition = WeatherCondition.Sun
            });

            var sut = new HomeController(mockWeatherForecaster.Object);
            var result = sut.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Contains("It's sunny right now.", model.WeatherDescription);
        }

        [Fact]
        public void ReturnsExpectedViewModel_WhenWeatherIsRainy()
        {
            var mockWeatherForecaster = new Mock<IWeatherForecaster>();
            mockWeatherForecaster.Setup(w => w.GetCurrentWeather()).Returns(new WeatherResult
            {
                WeatherCondition = WeatherCondition.Rain
            });

            var sut = new HomeController(mockWeatherForecaster.Object);
            var result = sut.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Contains("We're sorry but it's raining here.", model.WeatherDescription);
        }
    }
}
