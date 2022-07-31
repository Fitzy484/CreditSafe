using OpenWeather;

namespace CreditsafeCountryApi.Models
{
    public class CityResult
    {
        public string Name { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public int TouristRating { get; set; }

        public int DateEstablished { get; set; }

        public int EstimatedPopulation { get; set; }

        public string TwoDigitCode { get; set; }

        public string ThreeDigitCode { get; set; }

        public string CurrencyCode { get; set; }

        public WeatherData Weather { get; set; }
    }
}
