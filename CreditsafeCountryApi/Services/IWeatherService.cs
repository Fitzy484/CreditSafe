using OpenWeather;
namespace CreditsafeCountryApi.Services
{
    public interface IWeatherService
    {
        Task<WeatherData> GetWeather(string name);
    }
}
