using WeatherForecast.Shared;

namespace WeatherForecast.Web.Services
{
    public interface IWeatherForecastHttpService
    {
        Task<IEnumerable<WeatherForecastModel>> GetWeatherForecasts();
    }
    public class WeatherForecastHttpService : IWeatherForecastHttpService
    {
        private readonly HttpClient _httpClient;
        public WeatherForecastHttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        async Task<IEnumerable<WeatherForecastModel>> IWeatherForecastHttpService.GetWeatherForecasts()
        {
            IEnumerable<WeatherForecastModel>? forecasts =
                await _httpClient.GetFromJsonAsync<IEnumerable<WeatherForecastModel>>("/WeatherForecast");
            return forecasts ?? Enumerable.Empty<WeatherForecastModel>();
        }
    }
}
