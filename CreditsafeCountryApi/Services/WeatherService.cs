using OpenWeather;
namespace CreditsafeCountryApi.Services
{
    public class WeatherService : IWeatherService
    {
        public async Task<WeatherData> GetWeather(string name, string countryCode)
        {

            try
            {
                var apiKey = "81d43709badad0b351c9f40d1c2f647f";

                OpenWeatherClient client = new OpenWeatherClient(apiKey);
                WeatherData weather = await client.GetWeatherAsync(name);

                return weather;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error returned from weather api{ex.Message}");
            }
        }
    }
}
