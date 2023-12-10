using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeatherForecast.Web.Models;
using WeatherForecast.Web.Services;

namespace WeatherForecast.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherForecastHttpService _weatherForecastHttpService;
        private readonly ILogger<HomeController> _logger;
        public HomeController(
            IWeatherForecastHttpService weatherForecastHttpService,
            ILogger<HomeController> logger)
        {
            _weatherForecastHttpService = weatherForecastHttpService;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Fetching weather forecast api...");
            var response = await _weatherForecastHttpService.GetWeatherForecasts();
            _logger.LogInformation($"Weather forecast data contains {response.Count()}");

            return View(response);
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