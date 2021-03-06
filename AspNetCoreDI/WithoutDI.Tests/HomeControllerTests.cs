using Microsoft.AspNetCore.Mvc;
using WithoutDI.Web.Controllers;
using WithoutDI.Web.Models;
using Xunit;

namespace WithoutDI.Tests
{
    public class HomeControllerTests
    {
        [Fact]
        public void ReturnsExpectedViewModel_WhenWeatherIsSun()
        {
            var sut = new HomeController();
            var result = sut.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Contains("It's sunny right now.", model.WeatherDescription);
        }

        [Fact]
        public void ReturnsExpectedViewModel_WhenWeatherIsRain()
        {
            var sut = new HomeController();
            var result = sut.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<HomeViewModel>(viewResult.ViewData.Model);
            Assert.Contains("We're sorry but it's raining here.", model.WeatherDescription);
        }
    }
}
